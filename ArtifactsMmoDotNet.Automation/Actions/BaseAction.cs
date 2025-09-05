using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;

namespace ArtifactsMmoDotNet.Automation.Actions;

public abstract class BaseAction : IAction
{
    public abstract string Name { get; }

    public virtual IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context,
        CancellationToken cancellationToken = default) =>
        AsyncEnumerable.Empty<IRequirement>();

    public abstract Task<ActionExecutionResult> Execute(IAutomationContext context,
        CancellationToken cancellationToken = default);
}
