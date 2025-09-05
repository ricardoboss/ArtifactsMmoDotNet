using System.Runtime.CompilerServices;
using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;
using ArtifactsMmoDotNet.Automation.Requirements;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class GatherItemAction(string itemCode) : BaseAction
{
    public override string Name => $"Gather {itemCode}";

    public override async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        yield return new HaveSpaceInInventoryRequirement(itemCode: itemCode);
    }

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context,
        CancellationToken cancellationToken = default)
    {
        int amountGathered;
        do
        {
            await using var _ = context.Game.SuspendAutoWaitForCooldownAsync(cancellationToken);

            var result = await context.Game.AsCharacter(context.CharacterName).Gather(cancellationToken);
            amountGathered = result.Details!.Items!.FirstOrDefault(i => i.Code == itemCode)?.Quantity!.Value ?? 0;

            if (result.Details.Xp is { } xp)
                await context.Output.LogInfoAsync($"Gained {xp} xp", cancellationToken);

            if (result.Details!.Items!.Count > 1)
            {
                await context.Output.LogInfoAsync("Gathered:", cancellationToken);
                foreach (var log in result.Details!.Items!)
                {
                    await context.Output.LogInfoAsync($"    - {log.Quantity} {log.Code}", cancellationToken);
                }
            }
            else if (amountGathered > 0)
                await context.Output.LogInfoAsync($"Gathered {amountGathered} {itemCode}", cancellationToken);
        } while (amountGathered < 1);

        return ActionExecutionResult.Successful();
    }
}
