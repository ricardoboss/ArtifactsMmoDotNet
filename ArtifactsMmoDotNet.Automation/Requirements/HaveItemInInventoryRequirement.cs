using ArtifactsMmoDotNet.Api.Exceptions.General;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Actions;
using ArtifactsMmoDotNet.Automation.Exceptions;
using ArtifactsMmoDotNet.Automation.Interfaces;

namespace ArtifactsMmoDotNet.Automation.Requirements;

public class HaveItemInInventoryRequirement(string itemCode, int quantity = 1) : BaseRequirement
{
    public override string Name => $"Have {quantity} {itemCode} in inventory";

    public override async Task<bool> IsFulfilled(IAutomationContext context)
    {
        return await context.Game.FromCharacter(context.CharacterName).GetInventory()
            .AnyAsync(i => i.Code == itemCode && i.Quantity >= quantity);
    }

    public override async IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context)
    {
        var alreadyInInventory = await GetAmountOfItemInInventory(context, itemCode);
        var missing = quantity - alreadyInInventory;

        if (alreadyInInventory > 0)
            await context.Output.LogInfoAsync($"Already have {alreadyInInventory} {itemCode} in inventory");

        await context.Output.LogInfoAsync($"Need {missing} more {itemCode}");

        ItemSchema? item;
        try
        {
            item = await context.Game.GetItem(itemCode);
        }
        catch (NotFoundException)
        {
            item = null;
        }

        if (item == null)
        {
            yield return new FailureAction(this, $"Item not found: {itemCode}");
            yield break;
        }

        if (item.Craft is { } craftInfo)
        {
            yield return new CraftItemAction(itemCode, craftInfo, missing);
        }
        else if (item.Type == "resource")
        {
            var (x, y) = await context.Game.FromCharacter(context.CharacterName).GetPosition();
            var nearestGatherLocation = await GetNearestLocationForResource(context, itemCode, x, y);
            if (nearestGatherLocation is not null)
            {
                if (x != nearestGatherLocation.X!.Value || y != nearestGatherLocation.Y!.Value)
                    yield return new GoToLocationAction(nearestGatherLocation.X!.Value, nearestGatherLocation.Y!.Value);

                for (var i = 0; i < missing; i++)
                    yield return new GatherItemAction(itemCode);

                yield break;
            }

            var nearestMonsterLocation = await GetNearestMonsterForDrop(context, itemCode, x, y);
            if (nearestMonsterLocation is not null)
            {
                if (x != nearestMonsterLocation.X!.Value || y != nearestMonsterLocation.Y!.Value)
                    yield return new GoToLocationAction(nearestMonsterLocation.X!.Value,
                        nearestMonsterLocation.Y!.Value);

                var inInventory = alreadyInInventory;
                while (inInventory < quantity)
                {
                    yield return new FightAction();

                    inInventory = await GetAmountOfItemInInventory(context, itemCode);
                }

                yield break;
            }

            throw new NoPossibleLocationFoundException($"No location to gather/fight for {itemCode} found")
            {
                Requirement = this,
            };
        }
        else if (item.Type == "weapon")
        {
            var equippedInSlot = await TryFindItemInSlot(context, itemCode) ??
                                 throw new UnobtainableItemException($"Don't know how to get weapon {itemCode}")
                                 {
                                     Requirement = this,
                                 };

            yield return new UnequipItemInSlotAction(equippedInSlot);
        }
        else
        {
            throw new UnobtainableItemException($"Don't know how to get {missing} {itemCode} in inventory")
            {
                Requirement = this,
            };
        }
    }
}
