namespace ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

public interface IRequirement
{
    string Name { get; }

    Task<bool> IsFulfilled(IAutomationContext context);

    IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context);
}
