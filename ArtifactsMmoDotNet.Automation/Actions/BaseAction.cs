using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Actions;

public abstract class BaseAction : IAction
{
    public abstract string Name { get; }

    public virtual async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context)
    {
        yield break;
    }

    public abstract Task Execute(IAutomationContext context);
}
