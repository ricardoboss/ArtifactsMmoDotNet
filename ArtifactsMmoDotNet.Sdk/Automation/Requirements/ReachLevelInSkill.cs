using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Automation.Actions;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;

namespace ArtifactsMmoDotNet.Sdk.Automation.Requirements;

public class ReachLevelInSkill(string skill, int level) : BaseRequirement
{
    public override string Name => $"Reach level {level} in {skill}";

    public override async Task<bool> IsFulfilled(IAutomationContext context)
    {
        var currentSkill = await GetCurrentSkillInfo(context);

        return currentSkill.Level >= level;
    }

    private async Task<SkillInfo> GetCurrentSkillInfo(IAutomationContext context)
    {
        var character = await context.Game.From(context.CharacterName).GetEverything();

        return skill switch
        {
            "mining" => new SkillInfo(character.MiningLevel!.Value, character.MiningXp!.Value,
                character.MiningMaxXp!.Value),
            "woodcutting" => new SkillInfo(character.WoodcuttingLevel!.Value, character.WoodcuttingXp!.Value,
                character.WoodcuttingMaxXp!.Value),
            "fishing" => new SkillInfo(character.FishingLevel!.Value, character.FishingXp!.Value,
                character.FishingMaxXp!.Value),
            "weaponcrafting" => new SkillInfo(character.WeaponcraftingLevel!.Value, character.WeaponcraftingXp!.Value,
                character.WeaponcraftingMaxXp!.Value),
            "gearcrafting" => new SkillInfo(character.GearcraftingLevel!.Value, character.GearcraftingXp!.Value,
                character.GearcraftingMaxXp!.Value),
            "jewelrycrafting" => new SkillInfo(character.JewelrycraftingLevel!.Value,
                character.JewelrycraftingXp!.Value, character.JewelrycraftingMaxXp!.Value),
            "cooking" => new SkillInfo(character.CookingLevel!.Value, character.CookingXp!.Value,
                character.CookingMaxXp!.Value),
            _ => throw new NotImplementedException($"Unknown skill: {skill}"),
        };
    }

    public override IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context)
    {
        return skill switch
        {
            "mining" => GatherItems(context, GatheringSkill.Mining),
            "woodcutting" => GatherItems(context, GatheringSkill.Woodcutting),
            "fishing" => GatherItems(context, GatheringSkill.Fishing),
            "weaponcrafting" => GetWeaponcraftingActions(context),
            "gearcrafting" => GetGearcraftingActions(context),
            "jewelrycrafting" => GetJewelrycraftingActions(context),
            "cooking" => GetCookingActions(context),
            _ => throw new NotImplementedException($"Don't know how to gain levels in {skill}"),
        };
    }

    private async IAsyncEnumerable<IAction> GatherItems(IAutomationContext context,
        GatheringSkill gatherSkill)
    {
        var currentInfo = await GetCurrentSkillInfo(context);
        var lastInfo = currentInfo;
        var position = await context.Game.From(context.CharacterName).GetPosition();
        var dropInfo = await GetNearestSkillLevellingInfo(context, gatherSkill, currentInfo, position);

        if (dropInfo.location is not { X: { } x, Y: { } y })
            throw new Exception("No location to level the skill found");

        if (position.x != x || position.y != y)
            yield return new GoToLocationAction(x, y);

        await context.Output.LogInfoAsync($"Need {currentInfo.XpToNextLevel} xp to level up");

        do
        {
            yield return new GatherItemAction(dropInfo.item.Code!);

            currentInfo = await GetCurrentSkillInfo(context);
            if (currentInfo.Level == lastInfo.Level)
                continue;

            lastInfo = currentInfo;

            await context.Output.LogInfoAsync($"Levelled up to level {currentInfo.Level} in {skill}");

            if (currentInfo.Level >= level)
                break;

            await context.Output.LogInfoAsync($"Need {currentInfo.XpToNextLevel} xp to level up again");

            // TODO: recheck if there is a better spot to level up
        } while (currentInfo.Level < level);
    }

    private static async Task<(DropRateSchema item, MapSchema? location)> GetNearestSkillLevellingInfo(
        IAutomationContext context, GatheringSkill gatherSkill,
        SkillInfo currentInfo, (int x, int y) position)
    {
        var resourcesForSkill = await context.Game
            .GetResources(
                // TODO: figure out how to get the min level as high as possible but have at least some resources
                // minLevel: currentInfo.Level,
                maxLevel: currentInfo.Level
            )
            .Where(r => r.Skill == gatherSkill)
            .ToListAsync();

        var dropLocations = await resourcesForSkill
            .ToAsyncEnumerable()
            .SelectAwait(async resource =>
            {
                var mostCommonDrop = resource.Drops!.OrderBy(d => d.Rate).First();

                var location =
                    await GetNearestLocationForResource(context, mostCommonDrop.Code!, position.x, position.y);

                return (item: mostCommonDrop, location);
            })
            .Where(t => t.location is not null)
            .ToListAsync();

        var dropInfo = dropLocations
            .OrderBy(t => EuclideanDistanceFrom(t.location!, position.x, position.y) / t.item.Rate)
            .FirstOrDefault();

        return dropInfo;
    }

    private IAsyncEnumerable<IAction> GetWeaponcraftingActions(IAutomationContext context)
    {
        throw new NotImplementedException();
    }

    private IAsyncEnumerable<IAction> GetGearcraftingActions(IAutomationContext context)
    {
        throw new NotImplementedException();
    }

    private IAsyncEnumerable<IAction> GetJewelrycraftingActions(IAutomationContext context)
    {
        throw new NotImplementedException();
    }

    private IAsyncEnumerable<IAction> GetCookingActions(IAutomationContext context)
    {
        throw new NotImplementedException();
    }
}

internal record SkillInfo(int Level, int Xp, int MaxXp)
{
    internal int XpToNextLevel => MaxXp - Xp;
}
