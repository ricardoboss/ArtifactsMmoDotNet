using System.Runtime.CompilerServices;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;
using ArtifactsMmoDotNet.Automation.Requirements;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class UnequipItemInSlotAction(ItemSlot slot) : BaseAction
{
    public override string Name => $"Unequip item in slot {slot}";

    public override async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        yield return new HaveSpaceInInventoryRequirement();
    }

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context,
        CancellationToken cancellationToken = default)
    {
        _ = await context.Game.AsCharacter(context.CharacterName).Unequip(slot, cancellationToken);

        return ActionExecutionResult.Successful();
    }
}
