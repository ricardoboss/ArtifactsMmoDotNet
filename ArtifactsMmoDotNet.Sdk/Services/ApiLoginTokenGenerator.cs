using ArtifactsMmoDotNet.Sdk.Exceptions;
using ArtifactsMmoDotNet.Sdk.Interfaces.Factories;
using ArtifactsMmoDotNet.Sdk.Interfaces.Services;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class ApiLoginTokenGenerator(IArtifactsMmoApiClientFactory apiClientFactory) : ILoginTokenGenerator
{
    public async Task<string> GetTokenAsync(string username, string password)
    {
        var apiClient = apiClientFactory.CreateWithBasicAuth(username, password);

        var response = await apiClient.Token!.PostAsync();

        if (response is not { Token: { } token})
            throw new LoginFailureException("Invalid response from Artifacts MMO API");

        return token;
    }
}
