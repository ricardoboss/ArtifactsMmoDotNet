using ArtifactsMmoDotNet.Sdk.Interfaces;
using Spectre.Console.Cli;

namespace ArtifactsMmoDotNet.Cli.Commands;

internal sealed class LoginCommand(IInteractiveLoginService interactiveLoginService) : AsyncCommand<LoginCommand.Settings>
{
    public sealed class Settings : CommandSettings;

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var success = await interactiveLoginService.LoginWithUsernameAndPasswordAsync();

        return success ? 0 : 1;
    }
}
