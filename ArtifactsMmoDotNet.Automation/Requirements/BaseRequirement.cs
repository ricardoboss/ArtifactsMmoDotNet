using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Requirements;

public abstract class BaseRequirement : IRequirement
{
    public abstract string Name { get; }

    public abstract Task<bool> IsFulfilled(IAutomationContext context);

    public abstract IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context);

    protected static async Task<MapSchema?> GetNearestLocationForResource(IAutomationContext context, string itemCode,
        int x, int y)
    {
        var maps = await context.Game.GetResources(drop: itemCode).SelectMany(r =>
                context.Game.GetMaps(contentCode: r.Code!, contentType: MapContentType.Resource))
            .ToListAsync();

        return maps.MinBy(m => EuclideanDistanceFrom(m, x, y));
    }

    protected static double EuclideanDistanceFrom(MapSchema map, int x, int y) =>
        Math.Sqrt(Math.Pow(map.X!.Value - x, 2) + Math.Pow(map.Y!.Value - y, 2));
}
