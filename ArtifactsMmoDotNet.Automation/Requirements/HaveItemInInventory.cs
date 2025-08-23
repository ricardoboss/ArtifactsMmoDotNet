using ArtifactsMmoDotNet.Automation.Actions;
using ArtifactsMmoDotNet.Automation.Exceptions;
using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Requirements;

public class HaveItemInInventory(string itemCode, int quantity = 1) : BaseRequirement
{
    public override string Name => $"Have {quantity} {itemCode} in inventory";

    public override async Task<bool> IsFulfilled(IAutomationContext context)
    {
        return await context.Game.FromCharacter(context.CharacterName).GetInventory()
            .AnyAsync(i => i.Code == itemCode && i.Quantity >= quantity);
    }

    public override async IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context)
    {
        var alreadyInInventory = await context.Game.FromCharacter(context.CharacterName).GetInventory()
            .Where(i => i.Code == itemCode).SumAsync(i => i!.Quantity!.Value);
        var missing = quantity - alreadyInInventory;

        if (alreadyInInventory > 0)
            await context.Output.LogInfoAsync($"Already have {alreadyInInventory} {itemCode} in inventory");

        await context.Output.LogInfoAsync($"Need {missing} more {itemCode}");

        var item = await context.Game.GetItem(itemCode);
        if (item.Craft is { } craftInfo)
        {
            yield return new CraftItemAction(itemCode, craftInfo, missing);
        }
        else if (item.Type == "resource")
        {
            var position = await context.Game.FromCharacter(context.CharacterName).GetPosition();
            var nearest = await GetNearestLocationForResource(context, itemCode, position.x, position.y);
            if (nearest is null)
                throw new UnknownGatherLocationException($"No location to gather {itemCode} found")
                {
                    ItemCode = itemCode,
                };

            if (position.x != nearest.X!.Value || position.y != nearest.Y!.Value)
                yield return new GoToLocationAction(nearest.X!.Value, nearest.Y!.Value);

            for (var i = 0; i < missing; i++)
                yield return new GatherItemAction(itemCode);
        }
        else
        {
            throw new NotImplementedException($"Don't know how to get {missing} {itemCode} in inventory");
        }
    }
}
