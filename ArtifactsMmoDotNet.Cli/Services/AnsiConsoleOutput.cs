using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;
using Spectre.Console;

namespace ArtifactsMmoDotNet.Cli.Services;

internal sealed class AnsiConsoleOutput(IAnsiConsole console) : IOutput
{
    public Task ShowConfirmationAsync(string message)
    {
        console.MarkupLine($"[green]{message}[/]");

        return Task.CompletedTask;
    }

    public Task LogInfoAsync(string message)
    {
        console.MarkupLine($"[grey]{message}[/]");

        return Task.CompletedTask;
    }
}
