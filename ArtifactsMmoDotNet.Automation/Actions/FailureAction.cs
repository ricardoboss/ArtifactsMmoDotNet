using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class FailureAction(IRequirement requirement, string message) : BaseAction
{
    public override string Name => $"Fulfil {requirement.Name}";

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context, CancellationToken cancellationToken = default) =>
        ActionExecutionResult.Failed(message, false);
}
