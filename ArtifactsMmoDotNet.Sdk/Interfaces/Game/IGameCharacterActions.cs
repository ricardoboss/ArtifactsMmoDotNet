using ArtifactsMmoDotNet.Api.Generated.Models;

namespace ArtifactsMmoDotNet.Sdk.Interfaces.Game;

public interface IGameCharacterActions
{
    Task<CharacterFightDataSchema> Attack();

    Task<CharacterMovementDataSchema> MoveTo(int x, int y);

    Task<SkillDataSchema> Gather();

    Task<EquipRequestSchema> Unequip(ItemSlot slot);

    Task<SkillDataSchema> Craft(string itemCode, int quantity = 1);

    Task<EquipRequestSchema> Equip(ItemSlot slot, string itemCode);
}
