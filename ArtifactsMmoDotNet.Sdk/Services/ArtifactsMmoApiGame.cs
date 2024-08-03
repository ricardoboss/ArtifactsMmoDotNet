using ArtifactsMmoDotNet.Api.Generated;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Interfaces;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class ArtifactsMmoApiGame(ArtifactsMmoApiClient apiClient) : IGame
{
    public IGame.IActions With(string characterName) => new Actions(this, characterName, apiClient);

    public IGame.ICharacters From(string characterName) => new Characters(this, characterName, apiClient);

    public async Task<IEnumerable<CharacterSchema>> GetCharacters()
    {
        return (await apiClient.My!.Characters!.GetAsync())!.Data!;
    }

    private DateTimeOffset _lastCooldownEnd = DateTimeOffset.MinValue;

    internal void UpdateCooldownEnd(DateTimeOffset end)
    {
        _lastCooldownEnd = end;
    }

    public TimeSpan RemainingCooldown
    {
        get
        {
            if (_lastCooldownEnd < DateTimeOffset.UtcNow)
                return TimeSpan.Zero;

            return _lastCooldownEnd - DateTimeOffset.UtcNow;
        }
    }

    public IEnumerable<IKnownLocation> KnownLocations => [
        new Location("Cooking Workshop", (1, 1)),
        new Location("Weaponcrafting Workshop", (2, 1)),
        new Location("Gearcrafting Workshop", (3, 1)),
        new Location("Bank", (4, 1)),
        new Location("Grand Exchange", (5, 1)),
        new Location("Tasks Master", (1, 2)),
        new Location("Jewelerycrafting Workshop", (1, 2)),
        new Location("Mining Workshop", (1, 5)),
    ];
}

file record Location(string Name, (int x, int y) Position) : IKnownLocation;

file class Actions(ArtifactsMmoApiGame game, string characterName, ArtifactsMmoApiClient apiClient) : IGame.IActions
{
    public async Task<CharacterFightDataSchema> Attack()
    {
        var result = (await apiClient.My![characterName]!.Action!.Fight!.PostAsync())!.Data!;

        game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }

    public async Task<CharacterMovementDataSchema> MoveTo(int x, int y)
    {
        var destination = new DestinationSchema
        {
            X = x,
            Y = y,
        };

        var result = (await apiClient.My![characterName]!.Action!.Move!.PostAsync(destination))!.Data!;

        game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }

    public async Task<SkillDataSchema> Gather()
    {
        var result = (await apiClient.My![characterName]!.Action!.Gathering!.PostAsync())!.Data!;

        game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }

    public async Task<EquipRequestSchema> Unequip(UnequipSchema_slot slot)
    {
        var result = (await apiClient.My![characterName]!.Action!.Unequip!.PostAsync(new UnequipSchema
        {
            Slot = slot,
        }))!.Data!;

        game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }

    public async Task<SkillDataSchema> Craft(string itemCode, int quantity = 1)
    {
        var result = (await apiClient.My![characterName]!.Action!.Crafting!.PostAsync(new CraftingSchema
        {
            Code = itemCode,
            Quantity = quantity,
        }))!.Data!;

        game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }

    public async Task<EquipRequestSchema> Equip(EquipSchema_slot slot, string itemCode)
    {
        var result = (await apiClient.My![characterName]!.Action!.Equip!.PostAsync(new EquipSchema
        {
            Slot = slot,
            Code = itemCode,
        }))!.Data!;

        game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }
}

file class Characters(ArtifactsMmoApiGame game,string characterName, ArtifactsMmoApiClient apiClient) : IGame.ICharacters
{
    private async Task<CharacterSchema> GetCharacterAsync()
    {
        return (await apiClient.Characters![characterName]!.GetAsync())!.Data!;
    }

    public async Task<(int x, int y)> GetPosition()
    {
        var character = await GetCharacterAsync();

        var cooldownEnd = DateTimeOffset.UtcNow.AddSeconds(character.Cooldown!.Value);

        game.UpdateCooldownEnd(cooldownEnd);

        return (character.X!.Value, character.Y!.Value);
    }

    public async Task<IEnumerable<InventorySlot>> GetInventory()
    {
        var character = await GetCharacterAsync();

        var cooldownEnd = DateTimeOffset.UtcNow.AddSeconds(character.Cooldown!.Value);

        game.UpdateCooldownEnd(cooldownEnd);

        return character.Inventory!.Where(i => i.Quantity!.Value > 0);
    }

    public async Task<IDictionary<EquipSchema_slot, string?>> GetEquipment()
    {
        var character = await GetCharacterAsync();

        var cooldownEnd = DateTimeOffset.UtcNow.AddSeconds(character.Cooldown!.Value);

        game.UpdateCooldownEnd(cooldownEnd);

        return new Dictionary<EquipSchema_slot, string?>
        {
            { EquipSchema_slot.Weapon, character.WeaponSlot },
            { EquipSchema_slot.Shield, character.ShieldSlot },
            { EquipSchema_slot.Helmet, character.HelmetSlot },
            { EquipSchema_slot.Body_armor, character.BodyArmorSlot },
            { EquipSchema_slot.Leg_armor, character.LegArmorSlot },
            { EquipSchema_slot.Boots, character.BootsSlot },
            { EquipSchema_slot.Ring1, character.Ring1Slot },
            { EquipSchema_slot.Ring2, character.Ring2Slot },
            { EquipSchema_slot.Amulet, character.AmuletSlot },
            { EquipSchema_slot.Artifact1, character.Artifact1Slot },
            { EquipSchema_slot.Artifact2, character.Artifact2Slot },
            { EquipSchema_slot.Artifact3, character.Artifact3Slot },
            { EquipSchema_slot.Consumable1, character.Consumable1Slot },
            { EquipSchema_slot.Consumable2, character.Consumable2Slot },
        };
    }
}
