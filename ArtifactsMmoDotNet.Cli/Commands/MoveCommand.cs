using ArtifactsMmoDotNet.Api.Generated;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Interfaces.Services;
using JetBrains.Annotations;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArtifactsMmoDotNet.Cli.Commands;

[UsedImplicitly]
internal sealed class MoveCommand(ArtifactsMmoApiClient apiClient, ILoginService loginService) : AsyncCommand<MoveCommand.Settings>
{
    [UsedImplicitly]
    internal sealed class Settings : CommandSettings;

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        if (!await loginService.IsLoggedInAsync())
        {
            AnsiConsole.MarkupLine("[red]You are not logged in. Please run the [yellow]login[/] command first.[/]");

            return 1;
        }

        var name = await AnsiConsole.AskAsync<string>("Character name: ");

        var character = await apiClient.Characters![name]!.GetAsync();
        var currentX = character!.Data!.X!;
        var currentY = character.Data!.Y!;

        AnsiConsole.MarkupLine($"[yellow]Current position:[/] ({currentX}, {currentY})");

        AnsiConsole.MarkupLine("[yellow]Move to:[/]");
        var x = await AnsiConsole.AskAsync<int>("X: ");
        var y = await AnsiConsole.AskAsync<int>("Y: ");

        var destination = new DestinationSchema
        {
            X = x,
            Y = y,
        };

        var movement = await apiClient.My![name]!.Action!.Move!.PostAsync(destination);

        AnsiConsole.MarkupLine($"Moved to ({movement!.Data!.Character!.X}, {movement.Data.Character.Y})");

        return 0;
    }
}
