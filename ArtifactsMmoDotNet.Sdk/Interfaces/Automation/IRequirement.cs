namespace ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

public interface IRequirement
{
    string Name { get; }

    TimeSpan Cooldown { get; }

    Task<bool> IsFulfilled(IAutomationContext context);

    IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context);
}
