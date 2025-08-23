namespace ArtifactsMmoDotNet.Automation.Interfaces;

public interface IRequirement
{
    string Name { get; }

    Task<bool> IsFulfilled(IAutomationContext context);

    IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context);
}
