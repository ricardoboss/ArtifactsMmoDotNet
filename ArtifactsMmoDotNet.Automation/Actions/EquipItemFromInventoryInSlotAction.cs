using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;
using ArtifactsMmoDotNet.Automation.Requirements;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class EquipItemFromInventoryInSlotAction(string itemCode, ItemSlot slot) : BaseAction
{
    public override string Name { get; } = $"Equip item in slot {slot}";

    public override async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context)
    {
        yield return new HaveItemInInventoryRequirement(itemCode);
    }

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context)
    {
        _ = await context.Game.AsCharacter(context.CharacterName).Equip(slot, itemCode);

        return ActionExecutionResult.Successful();
    }
}
