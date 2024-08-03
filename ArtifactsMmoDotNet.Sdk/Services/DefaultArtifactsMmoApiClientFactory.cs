using ArtifactsMmoDotNet.Api.Generated;
using ArtifactsMmoDotNet.Sdk.Interfaces;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class DefaultArtifactsMmoApiClientFactory(IHttpClientFactory httpClientFactory, IAccessTokenProvider accessTokenProvider) : IArtifactsMmoApiClientFactory
{
    public ArtifactsMmoApiClient Create()
    {
        var authProvider = new BaseBearerTokenAuthenticationProvider(accessTokenProvider);

        return CreateWith(authProvider);
    }

    public ArtifactsMmoApiClient CreateWithBasicAuth(string username, string password)
    {
        var authProvider = new BasicAuthenticationProvider(username, password);

        return CreateWith(authProvider);
    }

    private ArtifactsMmoApiClient CreateWith(IAuthenticationProvider authProvider)
    {
        var client = CreateHttpClient();
        var requestAdapter = new HttpClientRequestAdapter(authProvider, httpClient: client);

        return new ArtifactsMmoApiClient(requestAdapter);
    }

    private HttpClient CreateHttpClient()
    {
        var client = httpClientFactory.CreateClient();

        client.BaseAddress = new Uri("https://api.artifactsmmo.com/");
        client.DefaultRequestHeaders.Add("User-Agent", "ArtifactsMmoDotNet/1.0.0 (+https://github.com/ricardoboss/ArtifactsMmoDotNet)");
        client.Timeout = TimeSpan.FromSeconds(5);

        return client;
    }
}
