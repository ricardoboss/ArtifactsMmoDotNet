using ArtifactsMmoDotNet.Api.Generated.Items;
using ArtifactsMmoDotNet.Api.Generated.Maps;
using ArtifactsMmoDotNet.Api.Generated.Models;

namespace ArtifactsMmoDotNet.Sdk.Interfaces.Game;

public interface IGame
{
    public interface IActions
    {
        Task<CharacterFightDataSchema> Attack();

        Task<CharacterMovementDataSchema> MoveTo(int x, int y);

        Task<SkillDataSchema> Gather();

        Task<EquipRequestSchema> Unequip(ItemSlot slot);

        Task<SkillDataSchema> Craft(string itemCode, int quantity = 1);

        Task<EquipRequestSchema> Equip(ItemSlot slot, string itemCode);
    }

    IActions With(string characterName);

    public interface ICharacters
    {
        Task<CharacterSchema> GetEverything();

        Task<(int x, int y)> GetPosition();

        IAsyncEnumerable<InventorySlot> GetInventory();

        Task<IDictionary<ItemSlot, string?>> GetEquipment();
    }

    ICharacters From(string characterName);

    IAsyncEnumerable<CharacterSchema> GetCharacters();

    TimeSpan RemainingCooldown { get; }

    bool AutoWaitForCooldown { get; set; }

    Func<DateTimeOffset, Task>? OnAwaitCooldown { get; set; }

    Task WaitForCooldown();

    IAsyncEnumerable<MapSchema> GetMaps(string? contentCode = null, MapContentType? contentType = null);

    Task<MapSchema> GetMap(int x, int y);

    IAsyncEnumerable<ItemSchema> GetItems(string? craftMaterial = null,
        CraftSkill? craftSkill = null, int? minLevel = null, int? maxLevel = null,
        ItemType? type = null);

    Task<ItemSchema> GetItem(string itemCode);

    IAsyncEnumerable<ResourceSchema> GetResources(string? drop = null, int? minLevel = null, int? maxLevel = null);
}
