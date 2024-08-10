using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;
using Spectre.Console;

namespace ArtifactsMmoDotNet.Cli.Services;

public class AnsiConsoleOutput : IOutput
{
    public Task ShowConfirmationAsync(string message)
    {
        AnsiConsole.MarkupLine($"[green]{message}[/]");

        return Task.CompletedTask;
    }

    public Task LogInfoAsync(string message)
    {
        AnsiConsole.MarkupLine($"[grey]{message}[/]");

        return Task.CompletedTask;
    }
}
