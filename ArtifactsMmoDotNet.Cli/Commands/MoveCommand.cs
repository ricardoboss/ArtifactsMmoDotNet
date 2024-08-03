using ArtifactsMmoDotNet.Api.Generated;
using ArtifactsMmoDotNet.Api.Generated.Models;
using ArtifactsMmoDotNet.Sdk.Interfaces.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ArtifactsMmoDotNet.Cli.Commands;

internal sealed class MoveCommand(ArtifactsMmoApiClient apiClient, ILoginService loginService) : AsyncCommand<MoveCommand.Settings>
{
    public sealed class Settings : CommandSettings;

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        if (!await loginService.IsLoggedInAsync())
        {
            AnsiConsole.MarkupLine("[red]You are not logged in. Please run the [yellow]login[/] command first.[/]");

            return 1;
        }

        var name = AnsiConsole.Ask<string>("Character name: ");

        var character = await apiClient.Characters![name]!.GetAsync();
        var currentX = character!.Data!.X!;
        var currentY = character.Data!.Y!;

        AnsiConsole.MarkupLine($"[yellow]Current position:[/] ({currentX}, {currentY})");

        AnsiConsole.MarkupLine("[yellow]Move to:[/]");
        var x = AnsiConsole.Ask<int>("X: ");
        var y = AnsiConsole.Ask<int>("Y: ");

        var destination = new DestinationSchema
        {
            X = x,
            Y = y,
        };

        var movement = await apiClient.My![name]!.Action!.Move!.PostAsync(destination);

        return 0;
    }
}
