using ArtifactsMmoDotNet.Sdk.Interfaces.Services;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class TokenLoginService(ITokenStorage tokenStorage, ILoginTokenGenerator loginTokenGenerator) : ILoginService
{
    public async Task<bool> IsLoggedInAsync(CancellationToken cancellationToken = default)
    {
        var token = await tokenStorage.GetTokenAsync(cancellationToken);

        return !string.IsNullOrEmpty(token);
    }

    public async Task LoginAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        var token = await loginTokenGenerator.GetTokenAsync(username, password, cancellationToken);

        await tokenStorage.SetTokenAsync(token, cancellationToken);
    }

    public async Task LogoutAsync(CancellationToken cancellationToken = default) =>
        await tokenStorage.ClearTokenAsync(cancellationToken);
}
