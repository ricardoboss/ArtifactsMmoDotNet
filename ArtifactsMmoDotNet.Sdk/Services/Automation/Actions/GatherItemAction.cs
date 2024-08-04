using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Services.Automation.Actions;

public class GatherItemAction(string itemCode, int quantity = 1) : BaseAction
{
    public override string Name => $"Gather {quantity}x{itemCode}";

    public override TimeSpan Cooldown => TimeSpan.FromSeconds(25);

    public override async Task Execute(IAutomationContext context)
    {
        while (true)
        {
            await context.Game.With(context.CharacterName).Gather();

            var inventory = (await context.Game.From(context.CharacterName).GetInventory()).ToList();
            if (inventory.Any(i => i.Code == itemCode && i.Quantity >= quantity))
                break;

            await Task.Delay(context.Game.RemainingCooldown);
        }
    }
}
