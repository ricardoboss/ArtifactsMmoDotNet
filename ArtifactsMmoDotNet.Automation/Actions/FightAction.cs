using System.Runtime.CompilerServices;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;
using ArtifactsMmoDotNet.Automation.Requirements;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class FightAction : BaseAction
{
    public override string Name => "Fight";

    public override async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        yield return new HaveItemEquippedInSlotRequirement("wooden_staff", ItemSlot.Weapon);
        yield return new HaveMinimumHpRequirement(0.5);
        yield return new HaveSpaceInInventoryRequirement(); // TODO: ensure we have enough space for drops
    }

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context,
        CancellationToken cancellationToken = default)
    {
        await using var _ = context.Game.SuspendAutoWaitForCooldownAsync(cancellationToken);

        var result = await context.Game.AsCharacter(context.CharacterName).Attack(cancellationToken);

        await context.Output.LogInfoAsync($"Fight result: {result.Fight!.Result}", cancellationToken);

        if (result.Fight.Result is not FightResult.Loss)
        {
            if (result.Fight.Xp is { } xp)
                await context.Output.LogInfoAsync($"Gained {xp} xp", cancellationToken);

            if (result.Fight.Gold is { } gold)
                await context.Output.LogInfoAsync($"Received {gold} gold", cancellationToken);

            if (result.Fight.Drops is { Count: > 1 })
            {
                await context.Output.LogInfoAsync("Gathered:", cancellationToken);
                foreach (var log in result.Fight.Drops)
                {
                    await context.Output.LogInfoAsync($"    - {log.Quantity} {log.Code}", cancellationToken);
                }
            }
            else if (result.Fight.Drops is { Count: > 0 })
                await context.Output.LogInfoAsync(
                    $"Gathered {result.Fight.Drops.First().Quantity} {result.Fight.Drops.First().Code}",
                    cancellationToken);
        }

        await context.Game.WaitForCooldown(cancellationToken);

        if (result.Fight.Result is FightResult.Loss)
            return ActionExecutionResult.Failed("Lost fight and probably respawned somewhere else.",
                attemptRetry: true);

        return ActionExecutionResult.Successful();
    }
}
