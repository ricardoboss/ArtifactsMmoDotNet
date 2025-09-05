namespace ArtifactsMmoDotNet.Automation.Interfaces;

public interface IRequirement
{
    string Name { get; }

    Task<bool> IsFulfilled(IAutomationContext context, CancellationToken cancellationToken = default);

    IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context, CancellationToken cancellationToken = default);
}
