using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Requirements;

public abstract class BaseRequirementWithRequirementContext<T> : BaseRequirement where T : IAutomationContext
{
    protected abstract Task<T> GetRequirementContext(IAutomationContext context);

    public override async Task<bool> IsFulfilled(IAutomationContext context)
    {
        var requirementContext = await GetRequirementContext(context);

        return await IsFulfilled(requirementContext);
    }

    protected abstract Task<bool> IsFulfilled(T requirementContext);

    public override async IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context)
    {
        var requirementContext = await GetRequirementContext(context);

        await foreach (var action in GetFulfillingActions(requirementContext))
            yield return action;
    }

    protected abstract IAsyncEnumerable<IAction> GetFulfillingActions(T requirementContext);
}
