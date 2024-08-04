using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Automation;
using ArtifactsMmoDotNet.Sdk.Automation.Requirements;
using ArtifactsMmoDotNet.Sdk.Interfaces.Automation;
using ArtifactsMmoDotNet.Sdk.Interfaces.Game;
using ArtifactsMmoDotNet.Sdk.Interfaces.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArtifactsMmoDotNet.Cli.Commands;

internal sealed class InteractiveCommand(IGame game, ILoginService loginService)
    : AsyncCommand<InteractiveCommand.Settings>
{
    public sealed class Settings : CommandSettings;

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        if (!await loginService.IsLoggedInAsync())
        {
            AnsiConsole.MarkupLine("[red]You are not logged in. Please run the [yellow]login[/] command first.[/]");

            return 1;
        }

        var characterName = await SelectCharacter();

        var subCommandPrompt = new SelectionPrompt<string>
        {
            Title = "What do you want to do?",
            SearchEnabled = true,
            WrapAround = true,
        };

        subCommandPrompt.AddChoice("automation");
        subCommandPrompt
            .AddChoiceGroup("Actions", "move", "fight", "gather", "unequip", "craft", "equip", "go")
            .AddChoiceGroup("Info", "position", "inventory", "equipment")
            .AddChoiceGroup("Other", "switch character", "quit");

        do
        {
            if (game.RemainingCooldown > TimeSpan.Zero)
            {
                await AnsiConsole.Status().Spinner(Spinner.Known.Clock!)
                    .StartAsync("Waiting for cooldown...", async ctx =>
                    {
                        while (game.RemainingCooldown > TimeSpan.Zero)
                        {
                            await Task.Delay(100);

                            ctx.Status($"Cooldown: [blue]{game.RemainingCooldown.TotalSeconds:0.0}s[/] left");
                        }
                    });
            }

            var subcommand = AnsiConsole.Prompt(subCommandPrompt);

            switch (subcommand)
            {
                case "quit":
                case "exit":
                    return 0;
                case "position":
                    AnsiConsole.MarkupLine(
                        $"[yellow]Current position:[/] {await game.From(characterName).GetPosition()}");

                    continue;
                case "move":
                    await Move(characterName);

                    continue;
                case "fight":
                    await Fight(characterName);

                    continue;
                case "gather":
                    await Gather(characterName);

                    continue;
                case "unequip":
                    await Unequip(characterName);

                    continue;
                case "craft":
                    await Craft(characterName);

                    continue;
                case "inventory":
                    await PrintInventory(characterName);

                    continue;
                case "equip":
                    await Equip(characterName);

                    continue;
                case "equipment":
                    await PrintEquipment(characterName);

                    continue;
                case "go":
                    await Go(characterName);

                    continue;
                case "automation":
                    await Automation(characterName);

                    continue;
                case "switch character":
                    characterName = await SelectCharacter();

                    continue;
            }
        } while (true);
    }

    private async Task Automation(string characterName)
    {
        var context = new AutomationContext(game, characterName);

        // TODO: create cli prompts to build root requirement
        var rootRequirement = new HaveItemInInventory("wooden_stick");

        await FulfilRequirement(context, rootRequirement);
    }

    private static async Task FulfilRequirement(IAutomationContext context, IRequirement requirement)
    {
        if (await requirement.IsFulfilled(context))
        {
            AnsiConsole.MarkupLine($"[yellow]Requirement [green]{requirement.Name}[/] fulfilled![/]");

            return;
        }

        AnsiConsole.MarkupLine($"[yellow]Fulfilling requirement [green]{requirement.Name}[/][/]");

        await foreach (var action in requirement.GetFulfillingActions(context))
        {
            await foreach (var subRequirement in action.GetRequirements(context))
            {
                await FulfilRequirement(context, subRequirement);
            }

            AnsiConsole.MarkupLine($"[yellow]Executing action [green]{action.Name}[/][/]");

            await action.Execute(context);
        }
    }

    private async Task Go(string characterName)
    {
        var prompt = new SelectionPrompt<KnownLocationOrCancel>
        {
            Title = "Select a location",
            SearchEnabled = true,
            WrapAround = true,
            Converter = l => l.Location is null
                ? "Cancel"
                : $"{l.Location.Name} ({l.Location.X}, {l.Location.Y}) - provides {l.Location.Content!.MapContentSchema!.Type}",
        };

        var locations = await game.GetMaps().Select(l => new KnownLocationOrCancel(l)).ToListAsync();

        prompt.AddChoices(locations)
            .AddChoice(new KnownLocationOrCancel(null));

        var selection = AnsiConsole.Prompt(prompt);
        if (selection.Location is null)
            return;

        await MoveTo(characterName, selection.Location.X!.Value, selection.Location.Y!.Value);
    }

    private async Task PrintEquipment(string characterName)
    {
        var equipment = await GetEquipment(characterName);

        AnsiConsole.MarkupLine("[yellow]Equipment:[/]");

        foreach (var (slot, itemCode) in equipment.Where(kvp => !string.IsNullOrWhiteSpace(kvp.Value)))
            AnsiConsole.MarkupLine($"    Slot {slot}: {itemCode}");
    }

    private async Task Equip(string characterName)
    {
        var slotPrompt = new SelectionPrompt<EquipSchema_slot>
        {
            Title = "Select a slot",
            SearchEnabled = true,
            WrapAround = true,
            Converter = s => s.ToString(),
        }.AddChoices(Enum.GetValues<EquipSchema_slot>());

        var slot = AnsiConsole.Prompt(slotPrompt);

        var inventorySlots = await GetInventory(characterName);

        var itemCodePrompt = new SelectionPrompt<string>
        {
            Title = "Select an item",
            SearchEnabled = true,
            WrapAround = true,
        }.AddChoices(inventorySlots.Select(i => i.Code!));

        var itemCode = AnsiConsole.Prompt(itemCodePrompt);

        var result = await AnsiConsole.Status().Spinner(Spinner.Known.Dots!)
            .StartAsync("Equipping...", async _ => await game.With(characterName).Equip(slot, itemCode));

        AnsiConsole.MarkupLine($"[yellow]Equipped item [green]{result.Item!.Code}[/][/]");
    }

    private async Task<IEnumerable<InventorySlot>> GetInventory(string characterName)
    {
        return await AnsiConsole.Status().Spinner(Spinner.Known.Dots!)
            .StartAsync("Fetching inventory...", async _ => await game.From(characterName).GetInventory());
    }

    private async Task<IDictionary<EquipSchema_slot, string?>> GetEquipment(string characterName)
    {
        return await AnsiConsole.Status().Spinner(Spinner.Known.Dots!)
            .StartAsync("Fetching equipment...", async _ => await game.From(characterName).GetEquipment());
    }

    private async Task PrintInventory(string characterName)
    {
        var inventorySlots = (await GetInventory(characterName)).ToList();

        AnsiConsole.MarkupLine("[yellow]Inventory:[/]");

        if (!inventorySlots.Any())
        {
            AnsiConsole.MarkupLine("[yellow]Your inventory is empty.[/]");

            return;
        }

        foreach (var item in inventorySlots)
            AnsiConsole.MarkupLine($"    Slot {item.Slot}: {item.Code} x{item.Quantity}");
    }

    private async Task Craft(string characterName)
    {
        var itemCode = AnsiConsole.Ask<string>("[yellow]What to craft?[/]");

        var result = await AnsiConsole.Status().Spinner(Spinner.Known.Dots!)
            .StartAsync($"Crafting {itemCode}...", async _ => await game.With(characterName).Craft(itemCode));

        PrintSkillDataResult(result);
    }

    private async Task Unequip(string characterName)
    {
        var slotPrompt = new SelectionPrompt<UnequipSchema_slot>
        {
            Title = "Select a slot",
            SearchEnabled = true,
            WrapAround = true,
            Converter = s => s.ToString(),
        }.AddChoices(Enum.GetValues<UnequipSchema_slot>());

        var slot = AnsiConsole.Prompt(slotPrompt);

        var result = await AnsiConsole.Status().Spinner(Spinner.Known.Dots!)
            .StartAsync("Unequipping...", async _ => await game.With(characterName).Unequip(slot));

        AnsiConsole.MarkupLine($"[yellow]Unequipped item [green]{result.Item!.Code}[/][/]");
    }

    private async Task Gather(string characterName)
    {
        var result = await AnsiConsole.Status().Spinner(Spinner.Known.Dots!)
            .StartAsync("Gathering...", async _ => await game.With(characterName).Gather());

        PrintSkillDataResult(result);
    }

    private void PrintSkillDataResult(SkillDataSchema result)
    {
        var xp = result.Details!.Xp!.Value;
        var inventory = result.Character!.Inventory!;
        var items = result.Details!.Items!.Select(s =>
        {
            var total = inventory.FirstOrDefault(i => i.Code == s.Code)?.Quantity ?? 0;

            return $"{s.Quantity}x {s.Code} ({total} total)";
        }).ToList();

        if (xp > 0)
            AnsiConsole.MarkupLine($"[yellow]Gained [green]+{xp} XP[/][/]");

        if (items.Any())
        {
            AnsiConsole.MarkupLine("[yellow]Received Items:[/]");

            foreach (var item in items)
                AnsiConsole.MarkupLine($"    {item}");
        }
    }

    private async Task Fight(string characterName)
    {
        var result = await AnsiConsole.Status().Spinner(Spinner.Known.Dots!)
            .StartAsync("Fighting...", async _ => await game.With(characterName).Attack());

        AnsiConsole.MarkupLine("[yellow]Fight Log:[/]");

        foreach (var log in result.Fight!.Logs!)
            AnsiConsole.MarkupLine($"   {log}");
    }

    private async Task Move(string characterName)
    {
        var position = await game.From(characterName).GetPosition();

        AnsiConsole.MarkupLine($"[yellow]Current position:[/] ({position.x}, {position.y})");

        string[] parts;
        int x, y;
        do
        {
            var coordinates = AnsiConsole.Ask<string>("[yellow]Move to:[/]");

            parts = coordinates.Split(',', 2);
        } while (parts is not [var xStr, var yStr] || !int.TryParse(xStr, out x) ||
                 !int.TryParse(yStr, out y));

        await MoveTo(characterName, x, y);
    }

    private async Task MoveTo(string characterName, int x, int y)
    {
        var result = await game.With(characterName).MoveTo(x, y);

        var destX = result.Destination!.X!.Value;
        var destY = result.Destination!.Y!.Value;
        var destinationName = result.Destination!.Name;

        AnsiConsole.MarkupLine($"[yellow]New position:[/] ({destX}, {destY})");

        if (destinationName != null)
            AnsiConsole.MarkupLine($"Arrived at [grey]{destinationName}[/]");
    }

    private async Task<string> SelectCharacter()
    {
        var characters = await AnsiConsole.Status().Spinner(Spinner.Known.Dots!).StartAsync("Fetching characters...",
            async _ =>
            {
                var characters = await game.GetCharacters();

                return characters.Select(c => c.Name!);
            });

        var characterSelectionPrompt = new SelectionPrompt<string>
        {
            Title = "Select a character",
            SearchEnabled = true,
        }.AddChoices(characters);

        return AnsiConsole.Prompt(characterSelectionPrompt);
    }
}

file record KnownLocationOrCancel(MapSchema? Location);
