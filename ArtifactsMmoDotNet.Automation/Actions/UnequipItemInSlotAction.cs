using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class UnequipItemInSlotAction(ItemSlot slot) : BaseAction
{
    public override string Name => $"Unequip item in slot {slot}";

    public override async Task<ActionExecutionResult> Execute(IAutomationContext context)
    {
        _ = await context.Game.AsCharacter(context.CharacterName).Unequip(slot);

        return ActionExecutionResult.Successful();
    }
}
