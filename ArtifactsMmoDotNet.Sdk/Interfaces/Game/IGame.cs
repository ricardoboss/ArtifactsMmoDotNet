using ArtifactsMmoDotNet.Api.Generated.Models;

namespace ArtifactsMmoDotNet.Sdk.Interfaces.Game;

public interface IGame
{
    public interface IActions
    {
        Task<CharacterFightDataSchema> Attack();

        Task<CharacterMovementDataSchema> MoveTo(int x, int y);

        Task<SkillDataSchema> Gather();

        Task<EquipRequestSchema> Unequip(UnequipSchema_slot slot);

        Task<SkillDataSchema> Craft(string itemCode, int quantity = 1);

        Task<EquipRequestSchema> Equip(EquipSchema_slot slot, string itemCode);
    }

    IActions With(string characterName);

    public interface ICharacters
    {
        Task<(int x, int y)> GetPosition();

        Task<IEnumerable<InventorySlot>> GetInventory();

        Task<IDictionary<EquipSchema_slot, string?>> GetEquipment();
    }

    ICharacters From(string characterName);

    Task<IEnumerable<CharacterSchema>> GetCharacters();

    TimeSpan RemainingCooldown { get; }

    IEnumerable<IKnownLocation> KnownLocations { get; }
}
