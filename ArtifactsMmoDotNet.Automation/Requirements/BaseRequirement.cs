using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Requirements;

public abstract class BaseRequirement : IRequirement
{
    public abstract string Name { get; }

    public abstract Task<bool> IsFulfilled(IAutomationContext context, CancellationToken cancellationToken = default);

    public abstract IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context,
        CancellationToken cancellationToken = default);

    protected static async Task<MapSchema?> GetNearestLocationForResource(IAutomationContext context, string itemCode,
        int x, int y, CancellationToken cancellationToken = default)
    {
        var maps = await context.Game.GetResources(drop: itemCode, cancellationToken: cancellationToken).SelectMany(r =>
                context.Game.GetMaps(contentCode: r.Code!, contentType: MapContentType.Resource,
                    cancellationToken: cancellationToken))
            .ToListAsync(cancellationToken: cancellationToken);

        return maps.MinBy(m => EuclideanDistanceFrom(m, x, y));
    }

    protected static async Task<MapSchema?> GetNearestMonsterForDrop(IAutomationContext context, string itemCode,
        int x, int y, CancellationToken cancellationToken = default)
    {
        var maps = await context.Game.GetMonsters(drop: itemCode, cancellationToken: cancellationToken).SelectMany(r =>
                context.Game.GetMaps(contentCode: r.Code!, contentType: MapContentType.Monster,
                    cancellationToken: cancellationToken))
            .ToListAsync(cancellationToken: cancellationToken);

        return maps.MinBy(m => EuclideanDistanceFrom(m, x, y));
    }

    protected static async Task<MapSchema?> GetNearestNpcForSelling(IAutomationContext context, string itemCode, int x,
        int y,
        CancellationToken cancellationToken = default)
    {
        var maps = await context.Game.GetNpcItems(itemCode, cancellationToken: cancellationToken).SelectMany(r =>
                context.Game.GetMaps(contentCode: r.Code!, contentType: MapContentType.Npc,
                    cancellationToken: cancellationToken))
            .ToListAsync(cancellationToken: cancellationToken);

        return maps.MinBy(m => EuclideanDistanceFrom(m, x, y));
    }

    protected static double EuclideanDistanceFrom(MapSchema map, int x, int y) =>
        Math.Sqrt(Math.Pow(map.X!.Value - x, 2) + Math.Pow(map.Y!.Value - y, 2));

    protected static async Task<int> GetAmountOfItemInInventory(IAutomationContext context, string itemCode)
    {
        return await context
            .Game
            .FromCharacter(context.CharacterName)
            .GetInventory()
            .Where(i => i.Code == itemCode)
            .SumAsync(i => i!.Quantity!.Value);
    }

    protected static async Task<ItemSlot?> TryFindItemInSlot(IAutomationContext context, string itemCode)
    {
        var equipment = await context
            .Game
            .FromCharacter(context.CharacterName)
            .GetEquipment();

        if (equipment.All(kvp => kvp.Value != itemCode))
            return null;

        return equipment.First(kvp => kvp.Value == itemCode).Key;
    }

    protected static async Task<string?> TryGetItemInSlot(IAutomationContext context, ItemSlot slot)
    {
        var equipment = await context
            .Game
            .FromCharacter(context.CharacterName)
            .GetEquipment();

        return string.IsNullOrWhiteSpace(equipment[slot]) ? null : equipment[slot];
    }
}
