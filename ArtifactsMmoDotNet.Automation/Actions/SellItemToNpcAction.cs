using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class SellItemToNpcAction(string itemCode, int quantity) : BaseAction
{
    public override string Name => $"Sell {quantity} {itemCode} to NPC";

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context)
    {
        _ = await context.Game.AsCharacter(context.CharacterName).SellToNpc(itemCode, quantity);

        return ActionExecutionResult.Successful();
    }
}
