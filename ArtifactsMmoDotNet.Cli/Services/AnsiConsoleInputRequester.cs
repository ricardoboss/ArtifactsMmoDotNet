using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;
using Spectre.Console;

namespace ArtifactsMmoDotNet.Cli.Services;

internal sealed class AnsiConsoleInputRequester(IAnsiConsole console) : IInputRequester
{
    public async Task<string> PromptAsync(string text, bool concealed = false,
        CancellationToken cancellationToken = default)
    {
        var prompt = new TextPrompt<string>(text);
        if (concealed)
            prompt.Secret();

        var response = await console.PromptAsync(prompt, cancellationToken: cancellationToken);

        return response;
    }
}
