using ArtifactsMmoDotNet.Api.Generated.Maps;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Automation.Actions;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Automation.Requirements;

public class HaveItemInInventory(string itemCode, int quantity = 1) : IRequirement
{
    public string Name => $"Have {quantity}x {itemCode} in inventory";

    public TimeSpan Cooldown => TimeSpan.FromSeconds(5);

    public async Task<bool> IsFulfilled(IAutomationContext context)
    {
        var inventory = await context.Game.From(context.CharacterName).GetInventory();

        return inventory.Any(i => i.Code == itemCode && i.Quantity >= quantity);
    }

    public async IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context)
    {
        var item = (await context.Game.GetItem(itemCode)).Item!;
        if (item.Craft is { CraftSchema: { } craftInfo })
        {
            yield return new CraftItemAction(itemCode, craftInfo, quantity);
        }
        else if (item.Type == "resource")
        {
            var map = await GetNearestLocationForResource(context);

            yield return new GoToLocationAction(map.X!.Value, map.Y!.Value);
            yield return new GatherItemAction(itemCode, quantity);
        }
        else
        {
            throw new NotImplementedException("Don't know how to get item in inventory");
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
