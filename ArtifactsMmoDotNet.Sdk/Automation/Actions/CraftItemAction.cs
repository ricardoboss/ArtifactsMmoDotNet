using ArtifactsMmoDotNet.Api.Generated.Maps;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Automation.Requirements;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Automation.Actions;

public class CraftItemAction(string itemCode, CraftSchema craft, int quantity = 1) : BaseAction
{
    public override string Name => $"Craft {quantity} {itemCode}";

    public override async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context)
    {
        // gather all items
        foreach (var requirement in craft.Items ?? [])
            yield return new HaveItemInInventory(requirement.Code!, quantity * requirement.Quantity!.Value);

        // make sure we have the required level
        // TODO: add requirement for skill level
    }

    public override async Task Execute(IAutomationContext context)
    {
        await GoToWorkshop(context);

        for (var i = 0; i < quantity; i++)
        {
            await context.Output.LogInfoAsync($"Crafting {itemCode}");

            var result = await context.Game.With(context.CharacterName).Craft(itemCode);

            if (result.Details!.Xp is { } xp)
                await context.Output.LogInfoAsync($"Gained {xp} xp");

            switch (result.Details!.Items!.Count)
            {
                case > 1:
                {
                    await context.Output.LogInfoAsync("Crafted:");
                    foreach (var log in result.Details!.Items!)
                    {
                        await context.Output.LogInfoAsync($"    - {log.Quantity} {log.Code}");
                    }

                    break;
                }
                case 1:
                {
                    var log = result.Details!.Items!.First();

                    await context.Output.LogInfoAsync($"Crafted {log.Quantity} {log.Code}");
                    break;
                }
            }

            await context.Game.WaitForCooldown();
        }
    }

    private async Task GoToWorkshop(IAutomationContext context)
    {
        var requiredSkill = craft.Skill!.Value.ToString();
        var workshopLocations = await context.Game
            .GetMaps(contentType: GetContent_typeQueryParameterType.Workshop)
            .Where(m => string.Equals(m.Content!.Code, requiredSkill, StringComparison.InvariantCultureIgnoreCase))
            .ToListAsync();

        var position = await context.Game.From(context.CharacterName).GetPosition();
        if (workshopLocations.Any(m => m.X!.Value == position.x && m.Y!.Value == position.y))
        {
            await context.Output.LogInfoAsync($"Already at {requiredSkill} workshop");

            return;
        }

        MapSchema nearestWorkshop;
        if (workshopLocations.Count == 1)
            nearestWorkshop = workshopLocations.Single();
        else
            nearestWorkshop = workshopLocations.OrderBy(m =>
                Math.Sqrt(Math.Pow(m.X!.Value - position.x, 2) + Math.Pow(m.Y!.Value - position.y, 2))).First();

        await context.Game.With(context.CharacterName).MoveTo(nearestWorkshop.X!.Value, nearestWorkshop.Y!.Value);

        await context.Output.LogInfoAsync(
            $"Moved to {nearestWorkshop.Content!.Code} workshop at {nearestWorkshop.X!.Value}, {nearestWorkshop.Y!.Value}");

        await context.Game.WaitForCooldown();
    }
}
