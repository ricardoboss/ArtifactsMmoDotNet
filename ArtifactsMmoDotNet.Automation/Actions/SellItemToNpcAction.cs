using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class SellItemToNpcAction(string itemCode, int quantity) : BaseAction
{
    public override string Name => $"Sell {quantity} {itemCode} to NPC";

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context, CancellationToken cancellationToken = default)
    {
        _ = await context.Game.AsCharacter(context.CharacterName).SellToNpc(itemCode, quantity, cancellationToken);

        return ActionExecutionResult.Successful();
    }
}
