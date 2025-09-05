using ArtifactsMmoDotNet.Automation.Models;

namespace ArtifactsMmoDotNet.Automation.Interfaces;

public interface IAction
{
    string Name { get; }

    IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context, CancellationToken cancellationToken = default);

    Task<ActionExecutionResult> Execute(IAutomationContext context, CancellationToken cancellationToken = default);
}
