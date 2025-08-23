using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;
using JetBrains.Annotations;
using Spectre.Console.Cli;

namespace ArtifactsMmoDotNet.Cli.Commands;

[UsedImplicitly]
internal sealed class LoginCommand(IInteractiveLoginService interactiveLoginService) : AsyncCommand<LoginCommand.Settings>
{
    [UsedImplicitly]
    internal sealed class Settings : CommandSettings;

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var success = await interactiveLoginService.LoginWithUsernameAndPasswordAsync();

        return success ? 0 : 1;
    }
}
