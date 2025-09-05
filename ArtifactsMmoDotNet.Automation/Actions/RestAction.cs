using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class RestAction : BaseAction
{
    public override string Name => "Rest";

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context, CancellationToken cancellationToken = default)
    {
        _ = await context.Game.AsCharacter(context.CharacterName).Rest(cancellationToken);

        return ActionExecutionResult.Successful();
    }
}
