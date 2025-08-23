using ArtifactsMmoDotNet.Api.Generated.Models;

namespace ArtifactsMmoDotNet.Sdk.Interfaces.Game;

public interface IGameCharacters
{
    Task<CharacterSchema> GetEverything();

    Task<(int x, int y)> GetPosition();

    IAsyncEnumerable<InventorySlot> GetInventory();

    Task<IDictionary<ItemSlot, string?>> GetEquipment();
}
