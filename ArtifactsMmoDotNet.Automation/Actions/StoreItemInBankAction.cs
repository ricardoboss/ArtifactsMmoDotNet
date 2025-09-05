using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class StoreItemInBankAction(string itemCode, int quantity) : BaseAction
{
    public override string Name => $"Store {quantity} {itemCode} in bank";

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context, CancellationToken cancellationToken = default)
    {
        _ = await context.Game.AsCharacter(context.CharacterName).StoreInBank(itemCode, quantity, cancellationToken);

        return ActionExecutionResult.Successful();
    }
}
