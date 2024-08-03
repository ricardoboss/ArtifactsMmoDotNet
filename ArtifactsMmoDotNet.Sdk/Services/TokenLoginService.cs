using ArtifactsMmoDotNet.Sdk.Interfaces.Services;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class TokenLoginService(ITokenStorage tokenStorage, ILoginTokenGenerator loginTokenGenerator) : ILoginService
{
    public async Task<bool> IsLoggedInAsync()
    {
        var token = await tokenStorage.GetTokenAsync();

        return !string.IsNullOrEmpty(token);
    }

    public async Task LoginAsync(string username, string password)
    {
        var token = await loginTokenGenerator.GetTokenAsync(username, password);

        await tokenStorage.SetTokenAsync(token);
    }

    public async Task LogoutAsync() => await tokenStorage.ClearTokenAsync();
}
