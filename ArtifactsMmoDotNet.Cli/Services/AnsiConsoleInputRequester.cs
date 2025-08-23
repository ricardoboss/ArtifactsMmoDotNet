using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;
using Spectre.Console;

namespace ArtifactsMmoDotNet.Cli.Services;

internal sealed class AnsiConsoleInputRequester(IAnsiConsole console) : IInputRequester
{
    public Task<string> PromptAsync(string text, bool concealed = false)
    {
        var prompt = new TextPrompt<string>(text);
        if (concealed)
            prompt.Secret();

        var response = console.Prompt(prompt);

        return Task.FromResult(response);
    }
}
