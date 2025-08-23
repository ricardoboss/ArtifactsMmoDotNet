using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Requirements;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Automation.Actions;

public class EquipItemInSlot(ItemSlot slot, string itemCode) : BaseAction
{
    public override string Name { get; } = $"Equip item in slot {slot}";

    public override async IAsyncEnumerable<IRequirement> GetRequirements(IAutomationContext context)
    {
        yield return new HaveItemInInventory(itemCode);
    }

    public override async Task Execute(IAutomationContext context)
    {
        _ = await context.Game.With(context.CharacterName).Equip(slot, itemCode);
    }
}
