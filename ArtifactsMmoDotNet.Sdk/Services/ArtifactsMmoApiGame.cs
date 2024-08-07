﻿using ArtifactsMmoDotNet.Api.Generated;
using ArtifactsMmoDotNet.Api.Generated.Items;
using ArtifactsMmoDotNet.Api.Generated.Maps;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Interfaces.Game;

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

    private readonly List<MapSchema> cachedLocations = [];

    public async Task WaitForCooldown() => await Task.Delay(RemainingCooldown);

    public async IAsyncEnumerable<MapSchema> GetMaps(string? contentCode = null,
        GetContent_typeQueryParameterType? contentType = null)
    {
        var useCache = contentCode is null && contentType is null;

        if (useCache && cachedLocations.Any())
        {
            foreach (var location in cachedLocations)
                yield return location;

            yield break;
        }

        const int size = 100;
        var page = 1;
        int pages;

        do
        {
            var maps = await apiClient.Maps!.GetAsync(c =>
            {
                c.QueryParameters.ContentCode = contentCode;
                c.QueryParameters.ContentType = contentType;
                c.QueryParameters.Page = page;
                c.QueryParameters.Size = size;
            });

            foreach (var map in maps!.Data!)
            {
                if (useCache)
                    cachedLocations.Add(map);

                yield return map;
            }

            page++;
            pages = maps.Pages!.Integer!.Value;
        } while (page <= pages);
    }

    public async Task<MapSchema> GetMap(int x, int y)
    {
        var map = await apiClient.Maps![x]![y]!.GetAsync();

        return map!.Data!;
    }

    private readonly List<ItemSchema> cachedItems = [];

    public async IAsyncEnumerable<ItemSchema> GetItems(string? craftMaterial = null,
        GetCraft_skillQueryParameterType? craftSkill = null, int? minLevel = null, int? maxLevel = null,
        GetTypeQueryParameterType? type = null)
    {
        var useCache = craftMaterial is null && craftSkill is null && minLevel is null && maxLevel is null &&
                       type is null;

        if (useCache && cachedItems.Any())
        {
            foreach (var item in cachedItems)
                yield return item;

            yield break;
        }

        const int size = 100;
        var page = 1;
        int pages;

        do
        {
            var items = await apiClient.Items!.GetAsync(c =>
            {
                c.QueryParameters.CraftMaterial = craftMaterial;
                c.QueryParameters.CraftSkill = craftSkill;
                c.QueryParameters.MaxLevel = maxLevel;
                c.QueryParameters.MinLevel = minLevel;
                c.QueryParameters.Type = type;
                c.QueryParameters.Page = page;
                c.QueryParameters.Size = size;
            });

            foreach (var item in items!.Data!)
            {
                if (useCache)
                    cachedItems.Add(item);

                yield return item;
            }

            page++;
            pages = items.Pages!.Integer!.Value;
        } while (page <= pages);
    }

    public async Task<SingleItemSchema> GetItem(string itemCode)
    {
        var item = await apiClient.Items![itemCode]!.GetAsync();

        return item!.Data!;
    }

    private readonly List<ResourceSchema> cachedResources = [];

    public async IAsyncEnumerable<ResourceSchema> GetResources(string? drop = null, int? minLevel = null, int? maxLevel = null)
    {
        var useCache = drop is null && minLevel is null && maxLevel is null;

        if (useCache && cachedResources.Any())
        {
            foreach (var resource in cachedResources)
                yield return resource;

            yield break;
        }

        const int size = 100;
        var page = 1;
        int pages;

        do
        {
            var resources = await apiClient.Resources!.GetAsync(c =>
            {
                c.QueryParameters.Drop = drop;
                c.QueryParameters.MinLevel = minLevel;
                c.QueryParameters.MaxLevel = maxLevel;
                c.QueryParameters.Page = page;
                c.QueryParameters.Size = size;
            });

            foreach (var resource in resources!.Data!)
            {
                if (useCache)
                    cachedResources.Add(resource);

                yield return resource;
            }

            page++;
            pages = resources.Pages!.Integer!.Value;
        } while (page <= pages);
    }
}

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

file class Characters(ArtifactsMmoApiGame game, string characterName, ArtifactsMmoApiClient apiClient)
    : IGame.ICharacters
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
