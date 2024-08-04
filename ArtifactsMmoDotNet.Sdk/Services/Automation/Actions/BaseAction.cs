using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Services.Automation.Actions;

public abstract class BaseAction : IAction
{
    public abstract string Name { get; }

    public abstract TimeSpan Cooldown { get; }

    public virtual async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context)
    {
        yield break;
    }

    public abstract Task Execute(IAutomationContext context);
}
