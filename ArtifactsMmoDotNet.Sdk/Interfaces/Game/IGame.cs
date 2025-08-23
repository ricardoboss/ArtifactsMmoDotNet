using ArtifactsMmoDotNet.Api.Generated.Models;

namespace ArtifactsMmoDotNet.Sdk.Interfaces.Game;

public interface IGame
{
    IGameCharacterActions AsCharacter(string characterName);

    IGameCharacters FromCharacter(string characterName);

    IAsyncEnumerable<CharacterSchema> GetCharacters();

    Task<CharacterSchema> CreateCharacter(string name, CharacterSkin? skin = null);

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
