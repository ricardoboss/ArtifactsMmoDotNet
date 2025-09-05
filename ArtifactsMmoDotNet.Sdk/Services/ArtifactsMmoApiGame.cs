using System.Runtime.CompilerServices;
using ArtifactsMmoDotNet.Api.Generated;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Interfaces.Game;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class ArtifactsMmoApiGame(ArtifactsMmoApiClient apiClient) : IGame
{
    public IGameCharacterActions AsCharacter(string characterName) =>
        new CharacterActions(this, characterName, apiClient);

    public IGameCharacters FromCharacter(string characterName) => new Characters(this, characterName, apiClient);

    public async IAsyncEnumerable<CharacterSchema> GetCharacters(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await apiClient.My.Characters.GetAsync(cancellationToken: cancellationToken);

        foreach (var character in response!.Data!)
            yield return character;
    }

    public async Task<CharacterSchema> CreateCharacter(string name, CharacterSkin? skin = null,
        CancellationToken cancellationToken = default)
    {
        var body = new AddCharacterSchema
        {
            Name = name,
            Skin = skin,
        };

        var response = await apiClient.Characters.Create.PostAsync(body, cancellationToken: cancellationToken);

        return response!.Data!;
    }

    private DateTimeOffset _lastCooldownEnd = DateTimeOffset.MinValue;

    internal Task UpdateCooldownEnd(DateTimeOffset end, CancellationToken cancellationToken = default)
    {
        _lastCooldownEnd = end;

        return AutoWaitForCooldown ? WaitForCooldown(cancellationToken) : Task.CompletedTask;
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

    public Task WaitForCooldown(CancellationToken cancellationToken = default) =>
        OnAwaitCooldown?.Invoke(_lastCooldownEnd) ?? Task.Delay(RemainingCooldown, cancellationToken);

    public async IAsyncEnumerable<MapSchema> GetMaps(string? contentCode = null, MapContentType? contentType = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var useCache = contentCode is null && contentType is null;

        if (useCache && cachedLocations.Count != 0)
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
            var maps = await apiClient.Maps.GetAsync(c =>
            {
                c.QueryParameters.ContentCode = contentCode;
                c.QueryParameters.ContentType = contentType;
                c.QueryParameters.Page = page;
                c.QueryParameters.Size = size;
            }, cancellationToken);

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

    public async Task<MapSchema> GetMap(int x, int y, CancellationToken cancellationToken = default)
    {
        var map = await apiClient.Maps[x][y].GetAsync(cancellationToken: cancellationToken);

        return map!.Data!;
    }

    private readonly List<ItemSchema> cachedItems = [];

    public async IAsyncEnumerable<ItemSchema> GetItems(string? craftMaterial = null,
        CraftSkill? craftSkill = null, int? minLevel = null, int? maxLevel = null,
        ItemType? type = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var useCache = craftMaterial is null && craftSkill is null && minLevel is null && maxLevel is null &&
                       type is null;

        if (useCache && cachedItems.Count != 0)
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
            var items = await apiClient.Items.GetAsync(c =>
            {
                c.QueryParameters.CraftMaterial = craftMaterial;
                c.QueryParameters.CraftSkill = craftSkill;
                c.QueryParameters.MaxLevel = maxLevel;
                c.QueryParameters.MinLevel = minLevel;
                c.QueryParameters.Type = type;
                c.QueryParameters.Page = page;
                c.QueryParameters.Size = size;
            }, cancellationToken);

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

    public async Task<ItemSchema> GetItem(string itemCode, CancellationToken cancellationToken = default)
    {
        var item = await apiClient.Items[itemCode].GetAsync(cancellationToken: cancellationToken);

        return item!.Data!;
    }

    private readonly List<ResourceSchema> cachedResources = [];

    public async IAsyncEnumerable<ResourceSchema> GetResources(string? drop = null, int? minLevel = null,
        int? maxLevel = null, GatheringSkill? skill = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var useCache = drop is null && minLevel is null && maxLevel is null && skill is null;

        if (useCache && cachedResources.Count != 0)
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
            var resources = await apiClient.Resources.GetAsync(c =>
            {
                c.QueryParameters.Drop = drop;
                c.QueryParameters.MinLevel = minLevel;
                c.QueryParameters.MaxLevel = maxLevel;
                c.QueryParameters.Page = page;
                c.QueryParameters.Size = size;
                c.QueryParameters.Skill = skill;
            }, cancellationToken);

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

    private readonly List<MonsterSchema> cachedMonsters = [];

    public async IAsyncEnumerable<MonsterSchema> GetMonsters(string? drop = null, int? minLevel = null,
        int? maxLevel = null, string? name = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var useCache = drop is null && minLevel is null && maxLevel is null && name is null;

        if (useCache && cachedMonsters.Count != 0)
        {
            foreach (var monster in cachedMonsters)
                yield return monster;

            yield break;
        }

        const int size = 100;
        var page = 1;
        int pages;

        do
        {
            var monsters = await apiClient.Monsters.GetAsync(c =>
            {
                c.QueryParameters.Drop = drop;
                c.QueryParameters.MinLevel = minLevel;
                c.QueryParameters.MaxLevel = maxLevel;
                c.QueryParameters.Page = page;
                c.QueryParameters.Size = size;
                c.QueryParameters.Name = name;
            }, cancellationToken);

            foreach (var monster in monsters!.Data!)
            {
                if (useCache)
                    cachedMonsters.Add(monster);

                yield return monster;
            }

            page++;
            pages = monsters.Pages!.Integer!.Value;
        } while (page <= pages);
    }

    private readonly List<NPCItem> cachedNPCItems = [];

    public async IAsyncEnumerable<NPCItem> GetNpcItems(string? itemCode = null, string? currency = null,
        string? npc = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var useCache = itemCode is null && currency is null && npc is null;

        if (useCache && cachedNPCItems.Count != 0)
        {
            foreach (var NPCItem in cachedNPCItems)
                yield return NPCItem;

            yield break;
        }

        const int size = 100;
        var page = 1;
        int pages;

        do
        {
            var NPCItems = await apiClient.Npcs.Items.GetAsync(c =>
            {
                c.QueryParameters.Code = itemCode;
                c.QueryParameters.Currency = currency;
                c.QueryParameters.Page = page;
                c.QueryParameters.Size = size;
                c.QueryParameters.Npc = npc;
            }, cancellationToken);

            foreach (var NPCItem in NPCItems!.Data!)
            {
                if (useCache)
                    cachedNPCItems.Add(NPCItem);

                yield return NPCItem;
            }

            page++;
            pages = NPCItems.Pages!.Integer!.Value;
        } while (page <= pages);
    }

    public IDisposable SuspendAutoWaitForCooldown() =>
        new SuspendedAutoWaitForCooldownDisposable(this, CancellationToken.None);

    public IAsyncDisposable SuspendAutoWaitForCooldownAsync(CancellationToken cancellationToken = default) =>
        new SuspendedAutoWaitForCooldownDisposable(this, cancellationToken);
}

file sealed class SuspendedAutoWaitForCooldownDisposable : IDisposable, IAsyncDisposable
{
    private readonly IGame game;
    private readonly CancellationToken cancellationToken;

    public SuspendedAutoWaitForCooldownDisposable(IGame game, CancellationToken cancellationToken)
    {
        this.game = game;
        this.cancellationToken = cancellationToken;

        game.AutoWaitForCooldown = false;
    }

    public void Dispose()
    {
        game.AutoWaitForCooldown = true;
    }

    public async ValueTask DisposeAsync()
    {
        Dispose();

        await game.WaitForCooldown(cancellationToken);
    }
}

file sealed class CharacterActions(ArtifactsMmoApiGame game, string characterName, ArtifactsMmoApiClient apiClient)
    : IGameCharacterActions
{
    public async Task<CharacterFightDataSchema> Attack(CancellationToken cancellationToken = default)
    {
        var result =
            (await apiClient.My[characterName].Action.Fight.PostAsync(cancellationToken: cancellationToken))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value, cancellationToken);

        return result;
    }

    public async Task<CharacterMovementDataSchema> MoveTo(int x, int y, CancellationToken cancellationToken = default)
    {
        var destination = new DestinationSchema
        {
            X = x,
            Y = y,
        };

        var result =
            (await apiClient.My[characterName].Action.Move.PostAsync(destination,
                cancellationToken: cancellationToken))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value, cancellationToken);

        return result;
    }

    public async Task<SkillDataSchema> Gather(CancellationToken cancellationToken = default)
    {
        var result =
            (await apiClient.My[characterName].Action.Gathering.PostAsync(cancellationToken: cancellationToken))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value, cancellationToken);

        return result;
    }

    public async Task<EquipRequestSchema> Unequip(ItemSlot slot, CancellationToken cancellationToken = default)
    {
        var result = (await apiClient.My[characterName].Action.Unequip.PostAsync(new()
        {
            Slot = slot,
        }, cancellationToken: cancellationToken))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value, cancellationToken);

        return result;
    }

    public async Task<SkillDataSchema> Craft(string itemCode, int quantity = 1,
        CancellationToken cancellationToken = default)
    {
        var result = (await apiClient.My[characterName].Action.Crafting.PostAsync(new()
        {
            Code = itemCode,
            Quantity = quantity,
        }, cancellationToken: cancellationToken))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value, cancellationToken);

        return result;
    }

    public async Task<EquipRequestSchema> Equip(ItemSlot slot, string itemCode,
        CancellationToken cancellationToken = default)
    {
        var result = (await apiClient.My[characterName].Action.Equip.PostAsync(new()
        {
            Slot = slot,
            Code = itemCode,
        }, cancellationToken: cancellationToken))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value, cancellationToken);

        return result;
    }

    public async Task<CharacterRestDataSchema> Rest(CancellationToken cancellationToken = default)
    {
        var result = (await apiClient.My[characterName].Action.Rest.PostAsync(cancellationToken: cancellationToken))!
            .Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value, cancellationToken);

        return result;
    }

    public async Task<NpcMerchantTransactionSchema> SellToNpc(string itemCode, int quantity,
        CancellationToken cancellationToken = default)
    {
        var body = new NpcMerchantBuySchema
        {
            Code = itemCode,
            Quantity = quantity,
        };

        var result = (await apiClient.My[characterName].Action.Npc.Sell
            .PostAsync(body, cancellationToken: cancellationToken))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value, cancellationToken);

        return result;
    }

    public async Task<BankItemTransactionSchema> StoreInBank(string itemCode, int quantity,
        CancellationToken cancellationToken = default)
    {
        var result = (await apiClient.My[characterName].Action.Bank.Deposit.Item.PostAsync([
            new()
            {
                Code = itemCode,
                Quantity = quantity,
            },
        ], cancellationToken: cancellationToken))!.Data!;

        await game.UpdateCooldownEnd(result.Cooldown!.Expiration!.Value, cancellationToken);

        return result;
    }
}

file sealed class Characters(ArtifactsMmoApiGame game, string characterName, ArtifactsMmoApiClient apiClient)
    : IGameCharacters
{
    public async Task<CharacterSchema> GetEverything(CancellationToken cancellationToken = default)
    {
        var character = await apiClient.Characters[characterName].GetAsync(cancellationToken: cancellationToken);

        await game.UpdateCooldownEnd(character!.Data!.CooldownExpiration!.Value, cancellationToken);

        return character.Data!;
    }

    public async Task<(int x, int y)> GetPosition(CancellationToken cancellationToken = default)
    {
        var character = await GetEverything(cancellationToken);

        return (character.X!.Value, character.Y!.Value);
    }

    public async IAsyncEnumerable<InventorySlot> GetInventory(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var character = await GetEverything(cancellationToken);

        foreach (var inventorySlot in character.Inventory!)
        {
            if (inventorySlot.Quantity!.Value <= 0)
                continue;

            yield return inventorySlot;
        }
    }

    public async Task<IDictionary<ItemSlot, string?>> GetEquipment(CancellationToken cancellationToken = default)
    {
        var character = await GetEverything(cancellationToken);

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
            { ItemSlot.Bag, character.BagSlot },
            { ItemSlot.Rune, character.RuneSlot },
        };
    }
}
