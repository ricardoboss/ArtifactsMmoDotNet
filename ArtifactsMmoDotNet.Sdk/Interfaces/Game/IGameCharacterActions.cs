using ArtifactsMmoDotNet.Api.Generated.Models;

namespace ArtifactsMmoDotNet.Sdk.Interfaces.Game;

public interface IGameCharacterActions
{
    Task<CharacterFightDataSchema> Attack(CancellationToken cancellationToken = default);

    Task<CharacterMovementDataSchema> MoveTo(int x, int y, CancellationToken cancellationToken = default);

    Task<SkillDataSchema> Gather(CancellationToken cancellationToken = default);

    Task<EquipRequestSchema> Unequip(ItemSlot slot, CancellationToken cancellationToken = default);

    Task<SkillDataSchema> Craft(string itemCode, int quantity = 1, CancellationToken cancellationToken = default);

    Task<EquipRequestSchema> Equip(ItemSlot slot, string itemCode, CancellationToken cancellationToken = default);

    Task<CharacterRestDataSchema> Rest(CancellationToken cancellationToken = default);

    Task<NpcMerchantTransactionSchema> SellToNpc(string itemCode, int quantity, CancellationToken cancellationToken = default);

    Task<BankItemTransactionSchema> StoreInBank(string itemCode, int quantity, CancellationToken cancellationToken = default);
}
