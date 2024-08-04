using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Automation.Requirements;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Automation.Actions;

public class EquipItemInSlot(EquipSchema_slot slot, string itemCode) : BaseAction
{
    public override string Name { get; } = $"Equip item in slot {slot}";

    public override TimeSpan Cooldown { get; } = TimeSpan.FromSeconds(2);

    public override async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context)
    {
        yield return new HaveItemInInventory(itemCode);
    }

    public override async Task Execute(IAutomationContext context)
    {
        _ = await context.Game.With(context.CharacterName).Equip(slot, itemCode);
    }
}