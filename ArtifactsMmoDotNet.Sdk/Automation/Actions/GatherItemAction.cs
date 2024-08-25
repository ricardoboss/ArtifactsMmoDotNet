using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Automation.Actions;

public class GatherItemAction(string itemCode) : BaseAction
{
    public override string Name => $"Gather {itemCode}";

    public override async Task Execute(IAutomationContext context)
    {
        int amountGathered;
        do
        {
            context.Game.AutoWaitForCooldown = false;
            var result = await context.Game.With(context.CharacterName).Gather();
            amountGathered = result.Details!.Items!.FirstOrDefault(i => i.Code == itemCode)?.Quantity!.Value ?? 0;

            if (result.Details.Xp is { } xp)
                await context.Output.LogInfoAsync($"Gained {xp} xp");

            if (result.Details!.Items!.Count > 1)
            {
                await context.Output.LogInfoAsync("Gathered:");
                foreach (var log in result.Details!.Items!)
                {
                    await context.Output.LogInfoAsync($"    - {log.Quantity} {log.Code}");
                }
            }
            else if (amountGathered > 0)
                await context.Output.LogInfoAsync($"Gathered {amountGathered} {itemCode}");

            await context.Game.WaitForCooldown();
            context.Game.AutoWaitForCooldown = true;
        } while (amountGathered < 1);
    }
}
