namespace ArtifactsMmoDotNet.Automation.Interfaces;

public interface IAction
{
    string Name { get; }

    IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context);

    Task Execute(IAutomationContext context);
}
