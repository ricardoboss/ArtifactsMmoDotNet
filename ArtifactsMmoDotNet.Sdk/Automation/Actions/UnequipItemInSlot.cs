using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Automation.Actions;

public class UnequipItemInSlot(ItemSlot slot) : BaseAction
{
    public override string Name => $"Unequip item in slot {slot}";

    public override async Task Execute(IAutomationContext context)
    {
        _ = await context.Game.With(context.CharacterName).Unequip(slot);
    }
}
