using ArtifactsMmoDotNet.Sdk.Interfaces;
using Spectre.Console;

namespace ArtifactsMmoDotNet.Cli.Services;

public class AnsiConsoleInputRequester : IInputRequester
{
    public Task<string> AskAsync(string message, bool concealed = false)
    {
        var prompt = new TextPrompt<string>(message);
        if (concealed)
            prompt.Secret();

        var response = AnsiConsole.Prompt(prompt);

        return Task.FromResult(response);
    }
}
