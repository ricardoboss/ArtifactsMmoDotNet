using ArtifactsMmoDotNet.Sdk.Interfaces.Services;
using Microsoft.Kiota.Abstractions.Authentication;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class TokenStorageAccessTokenProvider(ITokenStorage tokenStorage) : IAccessTokenProvider
{
    public async Task<string> GetAuthorizationTokenAsync(
        Uri uri,
        Dictionary<string, object>? additionalAuthenticationContext = null,
        CancellationToken cancellationToken = default
    )
    {
        var token = await tokenStorage.GetTokenAsync();

        return token ?? string.Empty;
    }

    public AllowedHostsValidator AllowedHostsValidator { get; } = new([
        "api.artifactsmmo.com",
    ]);
}

