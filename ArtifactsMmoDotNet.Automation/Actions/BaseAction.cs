using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Actions;

public abstract class BaseAction : IAction
{
    public abstract string Name { get; }

    public virtual IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context) =>
        AsyncEnumerable.Empty<IRequirement>();

    public abstract Task Execute(IAutomationContext context);
}
