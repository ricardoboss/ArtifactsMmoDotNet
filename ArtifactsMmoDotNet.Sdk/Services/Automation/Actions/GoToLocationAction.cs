using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Services.Automation.Actions;

public class GoToLocationAction(int x, int y) : BaseAction
{
    public override string Name => $"Go to ({x},{y})";

    public override TimeSpan Cooldown => TimeSpan.FromSeconds(35);

    public override async Task Execute(IAutomationContext context)
    {
        await context.Game.With(context.CharacterName).MoveTo(x, y);
    }
}
