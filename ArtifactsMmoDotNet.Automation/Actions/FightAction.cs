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
            foreach (var characterResult in result.Fight.Characters ?? [])
            {
                await context.Output.LogInfoAsync($"Character {characterResult.CharacterName}:", cancellationToken);
                await context.Output.LogInfoAsync($"    Has {characterResult.FinalHp} HP left", cancellationToken);

                if (characterResult.Xp is { } xp)
                    await context.Output.LogInfoAsync($"    Gained {xp} xp", cancellationToken);

                if (characterResult.Gold is { } gold)
                    await context.Output.LogInfoAsync($"    Received {gold} gold", cancellationToken);

                if (characterResult.Drops is { Count: > 1 })
                {
                    await context.Output.LogInfoAsync("    Gathered:", cancellationToken);
                    foreach (var log in characterResult.Drops)
                    {
                        await context.Output.LogInfoAsync($"        - {log.Quantity} {log.Code}", cancellationToken);
                    }
                }
                else if (characterResult.Drops is { Count: > 0 })
                    await context.Output.LogInfoAsync(
                        $"Gathered {characterResult.Drops.First().Quantity} {characterResult.Drops.First().Code}",
                        cancellationToken);
            }
        }

        await context.Game.WaitForCooldown(cancellationToken);

        if (result.Fight.Result is FightResult.Loss)
            return ActionExecutionResult.Failed("Lost fight and probably respawned somewhere else.",
                attemptRetry: true);

        return ActionExecutionResult.Successful();
    }
}
