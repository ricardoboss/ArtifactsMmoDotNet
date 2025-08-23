using System.Diagnostics;
using System.Text;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Actions;
using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Requirements;

public class HaveSpaceInInventoryRequirement(string? itemCode = null, int total = 1, bool allowSellingItems = false)
    : BaseRequirementWithRequirementContext<InventorySpaceContext>
{
    public override string Name
    {
        get
        {
            var sb = new StringBuilder();
            sb.Append("Have space for ");
            sb.Append(total);
            sb.Append(' ');
            if (itemCode != null)
                sb.Append(itemCode);
            else
            {
                sb.Append("item");
                if (total > 1)
                    sb.Append('s');
            }

            if (allowSellingItems)
                sb.Append(" (selling items allowed)");

            return sb.ToString();
        }
    }

    protected override async Task<InventorySpaceContext> GetRequirementContext(IAutomationContext context)
    {
        var character = await context.Game.FromCharacter(context.CharacterName).GetEverything();
        var max = character.InventoryMaxItems!.Value;
        var used = character.Inventory!.Sum(s => s.Quantity!.Value);
        var usedByItem = itemCode == null
            ? 0
            : character.Inventory!.Where(s => s.Code == itemCode).Sum(s => s.Quantity!.Value);

        return new(max, used, usedByItem, context);
    }

    protected override async Task<bool> IsFulfilled(InventorySpaceContext requirementContext) =>
        requirementContext.FreeSpace + requirementContext.UsedByItem >= total;

    protected override async IAsyncEnumerable<IAction> GetFulfillingActions(InventorySpaceContext requirementContext)
    {
        var itemQuantityToFreeUp = total - requirementContext.FreeSpace - requirementContext.UsedByItem;

        var (x, y) = await requirementContext.Game.FromCharacter(requirementContext.CharacterName).GetPosition();
        var valueOrderedItems = (await OrderItemsByValueAscending(requirementContext)).ToList();

        if (allowSellingItems)
            await foreach (var p in SellToNpc(requirementContext, valueOrderedItems, x, y, itemQuantityToFreeUp))
                yield return p;
        else
            await requirementContext.Output.LogInfoAsync("Storing some items in bank");

        if (x != 4 || y != 1)
            yield return new GoToLocationAction(4, 1); // FIXME: find bank dynamically
        yield return new StoreItemInBankAction(valueOrderedItems.First(), itemQuantityToFreeUp);
    }

    private async IAsyncEnumerable<IAction> SellToNpc(InventorySpaceContext requirementContext, List<string> valueOrderedItems, int x, int y,
        int itemQuantityToFreeUp)
    {
        MapSchema? nearest = null;
        string? lowestValueItemWithNpc = null;
        foreach (var itemToSell in valueOrderedItems)
        {
            await requirementContext.Output.LogInfoAsync($"Looking for an NPC to sell {itemToSell} to...");

            nearest = await GetNearestNpcForSelling(requirementContext, itemToSell, x, y);
            if (nearest != null)
            {
                lowestValueItemWithNpc = itemToSell;
                break;
            }
        }

        if (nearest != null)
        {
            Debug.Assert(lowestValueItemWithNpc != null);

            if (x != nearest.X!.Value || y != nearest.Y!.Value)
                yield return new GoToLocationAction(nearest.X!.Value, nearest.Y!.Value);

            yield return new SellItemToNpcAction(lowestValueItemWithNpc, itemQuantityToFreeUp);
        }

        await requirementContext.Output.LogInfoAsync("Couldn't find an NPC to sell items to, transferring items to bank instead");
    }

    private static async Task<IEnumerable<string>> OrderItemsByValueAscending(InventorySpaceContext requirementContext)
    {
        var itemsInInventory = await requirementContext.Game.FromCharacter(requirementContext.CharacterName).GetInventory().ToListAsync();

        return itemsInInventory.Select(s => s.Code!);
    }
}

public sealed record InventorySpaceContext(int MaxSpace, int UsedSpace, int UsedByItem, IAutomationContext Parent)
    : AutomationContext(Parent.Game, Parent.CharacterName, Parent.Output)
{
    public int FreeSpace => MaxSpace - UsedSpace;
}
