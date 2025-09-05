using ArtifactsMmoDotNet.Api.Exceptions.Account;
using ArtifactsMmoDotNet.Sdk.Exceptions;
using ArtifactsMmoDotNet.Sdk.Interfaces.Factories;
using ArtifactsMmoDotNet.Sdk.Interfaces.Services;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class ApiLoginTokenGenerator(IArtifactsMmoApiClientFactory apiClientFactory) : ILoginTokenGenerator
{
    public async Task<string> GetTokenAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        var apiClient = apiClientFactory.CreateWithBasicAuth(username, password);

        try
        {
            var response = await apiClient.Token!.PostAsync(cancellationToken: cancellationToken);

            if (response is not { Token: { } token })
                throw new LoginFailureException("Invalid response from Artifacts MMO API");

            return token;
        }
        catch (TokenGenerationFailException e)
        {
            throw new LoginFailureException("Failed to generate token. Verify your credentials.", e);
        }
    }
}
