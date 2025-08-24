using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Automation.Actions;
using ArtifactsMmoDotNet.Automation.Exceptions;
using ArtifactsMmoDotNet.Automation.Interfaces;
using ArtifactsMmoDotNet.Automation.Models;

namespace ArtifactsMmoDotNet.Automation.Requirements;

public class ReachLevelInSkillRequirement(LevelableSkill skill, int level) : BaseRequirement
{
    public override string Name => $"Reach level {level} in {skill}";

    public override async Task<bool> IsFulfilled(IAutomationContext context)
    {
        var currentSkill = await GetCurrentSkillInfo(context);

        return currentSkill.Level >= level;
    }

    private async Task<SkillInfo> GetCurrentSkillInfo(IAutomationContext context)
    {
        var character = await context.Game.FromCharacter(context.CharacterName).GetEverything();

        return skill switch
        {
            LevelableSkill.Mining => new(character.MiningLevel!.Value, character.MiningXp!.Value,
                character.MiningMaxXp!.Value),
            LevelableSkill.Woodcutting => new(character.WoodcuttingLevel!.Value,
                character.WoodcuttingXp!.Value,
                character.WoodcuttingMaxXp!.Value),
            LevelableSkill.Fishing => new(character.FishingLevel!.Value, character.FishingXp!.Value,
                character.FishingMaxXp!.Value),
            LevelableSkill.Weaponcrafting => new(character.WeaponcraftingLevel!.Value,
                character.WeaponcraftingXp!.Value,
                character.WeaponcraftingMaxXp!.Value),
            LevelableSkill.Gearcrafting => new(character.GearcraftingLevel!.Value,
                character.GearcraftingXp!.Value,
                character.GearcraftingMaxXp!.Value),
            LevelableSkill.Jewelrycrafting => new(character.JewelrycraftingLevel!.Value,
                character.JewelrycraftingXp!.Value, character.JewelrycraftingMaxXp!.Value),
            LevelableSkill.Cooking => new(character.CookingLevel!.Value, character.CookingXp!.Value,
                character.CookingMaxXp!.Value),
            LevelableSkill.Alchemy => new(character.AlchemyLevel!.Value, character.AlchemyXp!.Value,
                character.AlchemyMaxXp!.Value),
            _ => throw new NotImplementedException($"Unknown skill: {skill}"),
        };
    }

    public override IAsyncEnumerable<IAction> GetFulfillingActions(IAutomationContext context)
    {
        return skill switch
        {
            LevelableSkill.Mining => GatherItems(context, GatheringSkill.Mining),
            LevelableSkill.Woodcutting => GatherItems(context, GatheringSkill.Woodcutting),
            LevelableSkill.Fishing => GatherItems(context, GatheringSkill.Fishing),
            LevelableSkill.Weaponcrafting => GetWeaponcraftingActions(context),
            LevelableSkill.Gearcrafting => GetGearcraftingActions(context),
            LevelableSkill.Jewelrycrafting => GetJewelrycraftingActions(context),
            LevelableSkill.Cooking => GetCookingActions(context),
            LevelableSkill.Alchemy => GatherItems(context, GatheringSkill.Alchemy),
            _ => throw new NotImplementedException($"Don't know how to gain levels in {skill}"),
        };
    }

    private async IAsyncEnumerable<IAction> GatherItems(IAutomationContext context,
        GatheringSkill gatherSkill)
    {
        var currentInfo = await GetCurrentSkillInfo(context);
        var lastInfo = currentInfo;
        var position = await context.Game.FromCharacter(context.CharacterName).GetPosition();
        var (item, location) = await GetNearestSkillLevellingInfo(context, gatherSkill, currentInfo, position);

        if (location is not { X: { } x, Y: { } y })
            throw new NoPossibleLocationFoundException("No location to level the skill found")
            {
                Requirement = this,
            };

        if (position.x != x || position.y != y)
            yield return new GoToLocationAction(x, y);

        await context.Output.LogInfoAsync($"Need {currentInfo.XpToNextLevel} xp to level up");

        do
        {
            yield return new GatherItemAction(item.Code!);

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
                maxLevel: currentInfo.Level,
                skill: gatherSkill
            )
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

    private async IAsyncEnumerable<IAction> GetWeaponcraftingActions(IAutomationContext context)
    {
        yield return new FailureAction(this, $"Level not high enough: {skill} needs to be level {level}");
    }

    private async IAsyncEnumerable<IAction> GetGearcraftingActions(IAutomationContext context)
    {
        yield return new FailureAction(this, $"Level not high enough: {skill} needs to be level {level}");
    }

    private async IAsyncEnumerable<IAction> GetJewelrycraftingActions(IAutomationContext context)
    {
        yield return new FailureAction(this, $"Level not high enough: {skill} needs to be level {level}");
    }

    private async IAsyncEnumerable<IAction> GetCookingActions(IAutomationContext context)
    {
        yield return new FailureAction(this, $"Level not high enough: {skill} needs to be level {level}");
    }
}

internal sealed record SkillInfo(int Level, int Xp, int MaxXp)
{
    internal int XpToNextLevel => MaxXp - Xp;
}
