using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Automation.Actions;

public class GatherItemAction(string itemCode, int quantity = 1) : BaseAction
{
    public override string Name => $"Gather {quantity} {itemCode}";

    public override TimeSpan Cooldown => TimeSpan.FromSeconds(25);

    public override async Task Execute(IAutomationContext context)
    {
        for (var totalAmountGathered = 0; totalAmountGathered < quantity;)
        {
            var result = await context.Game.With(context.CharacterName).Gather();

            var amountGathered = result.Details!.Items!.First().Quantity!.Value;
            totalAmountGathered += amountGathered;

            var remaining = quantity - totalAmountGathered;

            await context.Output.LogInfoAsync($"Gathered {amountGathered} {itemCode} ({remaining} remaining)");

            if (context.Game.RemainingCooldown <= TimeSpan.Zero)
                continue;

            await context.Output.LogInfoAsync($"Cooldown: {context.Game.RemainingCooldown.TotalSeconds:0.0}s");

            await Task.Delay(context.Game.RemainingCooldown);
        }
    }
}
