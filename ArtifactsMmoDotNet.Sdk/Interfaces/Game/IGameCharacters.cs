using ArtifactsMmoDotNet.Api.Generated.Models;

namespace ArtifactsMmoDotNet.Sdk.Interfaces.Game;

public interface IGameCharacters
{
    Task<CharacterSchema> GetEverything(CancellationToken cancellationToken = default);

    Task<(int x, int y)> GetPosition(CancellationToken cancellationToken = default);

    IAsyncEnumerable<InventorySlot> GetInventory(CancellationToken cancellationToken = default);

    Task<IDictionary<ItemSlot, string?>> GetEquipment(CancellationToken cancellationToken = default);
}
