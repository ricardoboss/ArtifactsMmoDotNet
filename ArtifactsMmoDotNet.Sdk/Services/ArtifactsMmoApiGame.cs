using ArtifactsMmoDotNet.Api.Generated;
using ArtifactsMmoDotNet.Api.Generated.Items;
using ArtifactsMmoDotNet.Api.Generated.Maps;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Interfaces.Game;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class ArtifactsMmoApiGame(ArtifactsMmoApiClient apiClient) : IGame
{
    public IGame.IActions With(string characterName) => new Actions(this, characterName, apiClient);

    public IGame.ICharacters From(string characterName) => new Characters(this, characterName, apiClient);

    public async IAsyncEnumerable<CharacterSchema> GetCharacters()
    {
        var response = await apiClient.My!.Characters!.GetAsync();

        foreach (var character in response!.Data!)
            yield return character;
    }

    private DateTimeOffset _lastCooldownEnd = DateTimeOffset.MinValue;

    internal Task UpdateCooldownEnd(DateTimeOffset end)
    {
        _lastCooldownEnd = end;

        return AutoWaitForCooldown ? WaitForCooldown() : Task.CompletedTask;
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

    public bool AutoWaitForCooldown { get; set; }

    public Func<DateTimeOffset, Task>? OnAwaitCooldown { get; set; }

    private readonly List<MapSchema> cachedLocations = [];

    public Task WaitForCooldown() =>
        OnAwaitCooldown?.Invoke(_lastCooldownEnd) ?? Task.Delay(RemainingCooldown);

    public async IAsyncEnumerable<MapSchema> GetMaps(string? contentCode = null, string? contentType = null)
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

    public async Task<ItemSchema> GetItem(string itemCode)
    {
        var item = await apiClient.Items![itemCode]!.GetAsync();

        return item!.Data!;
    }

    private readonly List<ResourceSchema> cachedResources = [];

    public async IAsyncEnumerable<ResourceSchema> GetResources(string? drop = null, int? minLevel = null,
        int? maxLevel = null)
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

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

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

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }

    public async Task<SkillDataSchema> Gather()
    {
        var result = (await apiClient.My![characterName]!.Action!.Gathering!.PostAsync())!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }

    public async Task<EquipRequestSchema> Unequip(ItemSlot slot)
    {
        var result = (await apiClient.My![characterName]!.Action!.Unequip!.PostAsync(new UnequipSchema
        {
            Slot = slot,
        }))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }

    public async Task<SkillDataSchema> Craft(string itemCode, int quantity = 1)
    {
        var result = (await apiClient.My![characterName]!.Action!.Crafting!.PostAsync(new CraftingSchema
        {
            Code = itemCode,
            Quantity = quantity,
        }))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }

    public async Task<EquipRequestSchema> Equip(ItemSlot slot, string itemCode)
    {
        var result = (await apiClient.My![characterName]!.Action!.Equip!.PostAsync(new EquipSchema
        {
            Slot = slot,
            Code = itemCode,
        }))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value);

        return result;
    }
}

file class Characters(ArtifactsMmoApiGame game, string characterName, ArtifactsMmoApiClient apiClient)
    : IGame.ICharacters
{
    public async Task<CharacterSchema> GetEverything()
    {
        var character = await apiClient.Characters![characterName]!.GetAsync();

        await game.UpdateCooldownEnd(character!.Data!.CooldownExpiration!.Value);

        return character.Data!;
    }

    public async Task<(int x, int y)> GetPosition()
    {
        var character = await GetEverything();

        return (character.X!.Value, character.Y!.Value);
    }

    public async IAsyncEnumerable<InventorySlot> GetInventory()
    {
        var character = await GetEverything();

        foreach (var inventorySlot in character.Inventory!)
        {
            if (inventorySlot.Quantity!.Value <= 0)
                continue;

            yield return inventorySlot;
        }
    }

    public async Task<IDictionary<ItemSlot, string?>> GetEquipment()
    {
        var character = await GetEverything();

        return new Dictionary<ItemSlot, string?>
        {
            { ItemSlot.Weapon, character.WeaponSlot },
            { ItemSlot.Shield, character.ShieldSlot },
            { ItemSlot.Helmet, character.HelmetSlot },
            { ItemSlot.Body_armor, character.BodyArmorSlot },
            { ItemSlot.Leg_armor, character.LegArmorSlot },
            { ItemSlot.Boots, character.BootsSlot },
            { ItemSlot.Ring1, character.Ring1Slot },
            { ItemSlot.Ring2, character.Ring2Slot },
            { ItemSlot.Amulet, character.AmuletSlot },
            { ItemSlot.Artifact1, character.Artifact1Slot },
            { ItemSlot.Artifact2, character.Artifact2Slot },
            { ItemSlot.Artifact3, character.Artifact3Slot },
            { ItemSlot.Utility1, character.Utility1Slot },
            { ItemSlot.Utility2, character.Utility2Slot },
        };
    }
}
