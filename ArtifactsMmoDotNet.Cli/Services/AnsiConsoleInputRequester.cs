using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;
using Spectre.Console;

namespace ArtifactsMmoDotNet.Cli.Services;

public class AnsiConsoleInputRequester : IInputRequester
{
    public Task<string> PromptAsync(string text, bool concealed = false)
    {
        var prompt = new TextPrompt<string>(text);
        if (concealed)
            prompt.Secret();

        var response = AnsiConsole.Prompt(prompt);

        return Task.FromResult(response);
    }
}
