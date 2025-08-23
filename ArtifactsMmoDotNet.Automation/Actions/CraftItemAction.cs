using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;
using ArtifactsMmoDotNet.Automation.Requirements;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class CraftItemAction(string itemCode, CraftSchema craft, int quantity = 1) : BaseAction
{
    public override string Name => $"Craft {quantity} {itemCode}";

    public override async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context)
    {
        // gather all items
        foreach (var item in craft.Items ?? [])
            if (item is { Code: { } ingredientCode, Quantity: { } ingredientQuantity })
            {
                yield return new HaveSpaceInInventoryRequirement(ingredientCode, quantity * ingredientQuantity);
                yield return new HaveItemInInventoryRequirement(ingredientCode, quantity * ingredientQuantity);
            }

        yield return new HaveSpaceInInventoryRequirement(itemCode, quantity);

        // make sure we have the required level
        if (craft is { Skill: { } skill, Level: { } skillLevel })
            yield return new ReachLevelInSkillRequirement(skill switch
            {
                CraftSkill.Weaponcrafting => LevelableSkill.Weaponcrafting,
                CraftSkill.Gearcrafting => LevelableSkill.Gearcrafting,
                CraftSkill.Jewelrycrafting => LevelableSkill.Jewelrycrafting,
                CraftSkill.Cooking => LevelableSkill.Cooking,
                CraftSkill.Woodcutting => LevelableSkill.Woodcutting,
                CraftSkill.Mining => LevelableSkill.Mining,
                CraftSkill.Alchemy => LevelableSkill.Alchemy,
                _ => throw new NotImplementedException($"Unknown craft skill: {skill}"),
            }, skillLevel);
    }

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context)
    {
        await GoToWorkshop(context);

        for (var i = 0; i < quantity; i++)
        {
            await context.Output.LogInfoAsync($"Crafting {itemCode}");

            var result = await context.Game.AsCharacter(context.CharacterName).Craft(itemCode);

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

        return ActionExecutionResult.Successful();
    }

    private async Task GoToWorkshop(IAutomationContext context)
    {
        var requiredSkill = craft.Skill!.Value.ToString();
        var workshopLocations = await context.Game
            .GetMaps(contentType: MapContentType.Workshop)
            .Where(m => string.Equals(m.Content!.Code, requiredSkill, StringComparison.InvariantCultureIgnoreCase))
            .ToListAsync();

        var (x, y) = await context.Game.FromCharacter(context.CharacterName).GetPosition();
        if (workshopLocations.Any(m => m.X!.Value == x && m.Y!.Value == y))
        {
            await context.Output.LogInfoAsync($"Already at {requiredSkill} workshop");

            return;
        }

        MapSchema nearestWorkshop;
        if (workshopLocations.Count == 1)
            nearestWorkshop = workshopLocations.Single();
        else
            nearestWorkshop = workshopLocations.OrderBy(m =>
                Math.Sqrt(Math.Pow(m.X!.Value - x, 2) + Math.Pow(m.Y!.Value - y, 2))).First();

        await context.Game.AsCharacter(context.CharacterName)
            .MoveTo(nearestWorkshop.X!.Value, nearestWorkshop.Y!.Value);

        await context.Output.LogInfoAsync(
            $"Moved to {nearestWorkshop.Content!.Code} workshop at {nearestWorkshop.X!.Value}, {nearestWorkshop.Y!.Value}");

        await context.Game.WaitForCooldown();
    }
}
