using System.Runtime.CompilerServices;
using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Requirements;

public abstract class BaseRequirementWithRequirementContext<T> : BaseRequirement where T : IAutomationContext
{
    protected abstract Task<T> GetRequirementContext(IAutomationContext context,
        CancellationToken cancellationToken = default);

    public override async Task<bool> IsFulfilled(IAutomationContext context,
        CancellationToken cancellationToken = default)
    {
        var requirementContext = await GetRequirementContext(context, cancellationToken);

        return await IsFulfilled(requirementContext, cancellationToken);
    }

    protected abstract Task<bool> IsFulfilled(T requirementContext, CancellationToken cancellationToken = default);

    public override async IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var requirementContext = await GetRequirementContext(context, cancellationToken);

        await foreach (var action in GetFulfillingActions(requirementContext, cancellationToken))
            yield return action;
    }

    protected abstract IAsyncEnumerable<IAction> GetFulfillingActions(T requirementContext,
        CancellationToken cancellationToken = default);
}
