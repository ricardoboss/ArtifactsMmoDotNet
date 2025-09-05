using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;
using ArtifactsMmoDotNet.Sdk.Interfaces.Services;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class DefaultInteractiveLoginService(IInputRequester inputRequester, ILoginService loginService, IOutput output)
    : IInteractiveLoginService
{
    public async Task<bool> LoginWithUsernameAndPasswordAsync(string? username = null, string? password = null,
        CancellationToken cancellationToken = default)
    {
        username ??= await inputRequester.PromptAsync("Username: ", cancellationToken: cancellationToken);
        password ??=
            await inputRequester.PromptAsync("Password: ", concealed: true, cancellationToken: cancellationToken);

        await loginService.LoginAsync(username, password, cancellationToken);

        await output.ShowConfirmationAsync("Login information saved!", cancellationToken);

        return true;
    }
}
