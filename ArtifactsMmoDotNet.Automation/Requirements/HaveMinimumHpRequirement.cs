using System.Runtime.CompilerServices;
using ArtifactsMmoDotNet.Automation.Actions;
using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Requirements;

public class HaveMinimumHpRequirement(double percent) : BaseRequirement
{
    public override string Name => $"Have at least {percent:P} HP";

    public override async Task<bool> IsFulfilled(IAutomationContext context,
        CancellationToken cancellationToken = default)
    {
        return await GetHpPercent(context) >= percent;
    }

    public override async IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        yield return new RestAction();
    }

    private static async Task<double> GetHpPercent(IAutomationContext context)
    {
        var character = await context.Game.FromCharacter(context.CharacterName).GetEverything();

        return (double)character.Hp!.Value / character.MaxHp!.Value;
    }
}
