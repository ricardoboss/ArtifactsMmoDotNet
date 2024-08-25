using ArtifactsMmoDotNet.Api.Generated.Maps;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Automation.Actions;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Automation.Requirements;

public class HaveItemInInventory(string itemCode, int quantity = 1) : IRequirement
{
    public string Name => $"Have {quantity} {itemCode} in inventory";

    public async Task<bool> IsFulfilled(IAutomationContext context)
    {
        return await context.Game.From(context.CharacterName).GetInventory()
            .AnyAsync(i => i.Code == itemCode && i.Quantity >= quantity);
    }

    public async IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context)
    {
        var alreadyInInventory = await context.Game.From(context.CharacterName).GetInventory()
            .Where(i => i.Code == itemCode).SumAsync(i => i!.Quantity!.Value);
        var missing = quantity - alreadyInInventory;

        if (alreadyInInventory > 0)
            await context.Output.LogInfoAsync($"Already have {alreadyInInventory} {itemCode} in inventory");

        await context.Output.LogInfoAsync($"Need {missing} more {itemCode}");

        var item = (await context.Game.GetItem(itemCode)).Item!;
        if (item.Craft is { } craftInfo)
        {
            yield return new CraftItemAction(itemCode, craftInfo, missing);
        }
        else if (item.Type == "resource")
        {
            var map = await GetNearestLocationForResource(context);

            var position = await context.Game.From(context.CharacterName).GetPosition();
            if (position.x != map.X!.Value || position.y != map.Y!.Value)
                yield return new GoToLocationAction(map.X!.Value, map.Y!.Value);

            yield return new GatherItemAction(itemCode, missing);
        }
        else
        {
            throw new NotImplementedException($"Don't know how to get {missing} {itemCode} in inventory");
        }
    }

    private async Task<MapSchema> GetNearestLocationForResource(IAutomationContext context)
    {
        var maps = await context.Game.GetResources(drop: itemCode).SelectMany(r =>
                context.Game.GetMaps(contentCode: r.Code!, contentType: GetContent_typeQueryParameterType.Resource))
            .ToListAsync();
        var position = await context.Game.From(context.CharacterName).GetPosition();

        return maps.OrderBy(m => Math.Sqrt(Math.Pow(m.X!.Value - position.x, 2) + Math.Pow(m.Y!.Value - position.y, 2)))
            .First();
    }
}
