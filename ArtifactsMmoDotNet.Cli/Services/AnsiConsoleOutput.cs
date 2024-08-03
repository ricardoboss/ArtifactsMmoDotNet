using ArtifactsMmoDotNet.Sdk.Interfaces;
using Spectre.Console;

namespace ArtifactsMmoDotNet.Cli.Services;

public class AnsiConsoleOutput : IOutput
{
    public Task ShowConfirmationAsync(string message)
    {
        AnsiConsole.MarkupLine($"[green]{message}[/]");

        return Task.CompletedTask;
    }
}
