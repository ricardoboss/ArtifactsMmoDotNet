using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;
using ArtifactsMmoDotNet.Automation.Requirements;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class FightAction() : BaseAction
{
    public override string Name => "Fight";

    public override async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context)
    {
        yield return new HaveMinimumHp(0.5);
    }

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context)
    {
        context.Game.AutoWaitForCooldown = false;
        var result = await context.Game.AsCharacter(context.CharacterName).Attack();

        await context.Output.LogInfoAsync($"Fight result: {result.Fight!.Result}");

        if (result.Fight.Result is FightResult.Loss)
        {
            await context.Game.WaitForCooldown();
            context.Game.AutoWaitForCooldown = true;

            return ActionExecutionResult.Failed("Lost fight and probably respawned somewhere else.",
                attemptRetry: true);
        }

        if (result.Fight.Xp is { } xp)
            await context.Output.LogInfoAsync($"Gained {xp} xp");

        if (result.Fight.Gold is { } gold)
            await context.Output.LogInfoAsync($"Received {gold} gold");

        if (result.Fight.Drops is { Count: > 1 })
        {
            await context.Output.LogInfoAsync("Gathered:");
            foreach (var log in result.Fight.Drops)
            {
                await context.Output.LogInfoAsync($"    - {log.Quantity} {log.Code}");
            }
        }
        else if (result.Fight.Drops is { Count: > 0 })
            await context.Output.LogInfoAsync($"Gathered {result.Fight.Drops.First().Quantity} {result.Fight.Drops.First().Code}");

        await context.Game.WaitForCooldown();
        context.Game.AutoWaitForCooldown = true;

        return ActionExecutionResult.Successful();
    }
}
