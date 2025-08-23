using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class RestAction : BaseAction
{
    public override string Name => "Rest";

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context)
    {
        _ = await context.Game.AsCharacter(context.CharacterName).Rest();

        return ActionExecutionResult.Successful();
    }
}
