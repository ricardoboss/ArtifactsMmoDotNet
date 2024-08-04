using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Services.Automation.Actions;

public class UnequipItemInSlot(UnequipSchema_slot slot) : BaseAction
{
    public override string Name => $"Unequip item in slot {slot}";

    public override TimeSpan Cooldown => TimeSpan.FromSeconds(2);

    public override async Task Execute(IAutomationContext context)
    {
        _ = await context.Game.With(context.CharacterName).Unequip(slot);
    }
}
