using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;
using ArtifactsMmoDotNet.Sdk.Interfaces.Services;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class DefaultInteractiveLoginService(IInputRequester inputRequester, ILoginService loginService, IOutput output)
    : IInteractiveLoginService
{
    public async Task<bool> LoginWithUsernameAndPasswordAsync(string? username = null, string? password = null)
    {
        username ??= await inputRequester.AskAsync("Username: ");
        password ??= await inputRequester.AskAsync("Password: ", concealed: true);

        await loginService.LoginAsync(username, password);

        await output.ShowConfirmationAsync("Login information saved!");

        return true;
    }
}
