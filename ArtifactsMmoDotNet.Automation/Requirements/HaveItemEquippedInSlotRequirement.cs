using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Actions;
using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Requirements;

public class HaveItemEquippedInSlotRequirement(string itemCode, ItemSlot slot) : BaseRequirement
{
    public override string Name => $"Have item {itemCode} equipped in slot {slot}";

    public override async Task<bool> IsFulfilled(IAutomationContext context)
    {
        var maybeEquippedSlot = await TryFindItemInSlot(context, itemCode);

        return maybeEquippedSlot == slot;
    }

    public override async IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context)
    {
        if (await TryGetItemInSlot(context, slot) is { } itemInSlot)
        {
            await context.Output.LogInfoAsync($"Slot {slot} is occupied by {itemInSlot}");

            yield return new UnequipItemInSlotAction(slot);
        }

        yield return new EquipItemFromInventoryInSlotAction(itemCode, slot);
    }
}
