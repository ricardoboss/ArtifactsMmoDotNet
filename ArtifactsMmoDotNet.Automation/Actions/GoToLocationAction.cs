using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class GoToLocationAction(int x, int y) : BaseAction
{
    public override string Name => $"Go to ({x},{y})";

    public override async Task Execute(IAutomationContext context)
    {
        await context.Game.AsCharacter(context.CharacterName).MoveTo(x, y);

        await context.Game.WaitForCooldown();
    }
}
