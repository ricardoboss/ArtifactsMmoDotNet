using ArtifactsMmoDotNet.Api.Exceptions;
using ArtifactsMmoDotNet.Api.Generated;
using ArtifactsMmoDotNet.Sdk.Interfaces.Factories;
using Microsoft.Extensions.Options;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class DefaultArtifactsMmoApiClientFactory(
    IHttpClientFactory httpClientFactory,
    IAccessTokenProvider accessTokenProvider,
    IOptions<ArtifactsMmoApiClientOptions> options
) : IArtifactsMmoApiClientFactory
{
    public const string ArtifactsMmoApiClientName = "ArtifactsMmoApiClient";

    private const string DefaultBaseAddress = "https://api.artifactsmmo.com/";

    private static readonly TimeSpan DefaultTimeout =
#if DEBUG
            Timeout.InfiniteTimeSpan
#else
            TimeSpan.FromSeconds(5)
#endif
        ;

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
        var httpAdapter = new HttpClientRequestAdapter(authProvider, httpClient: client);
        var errorHandlerAdapter = new CustomErrorCodeHandlingRequestAdapter(httpAdapter);

        return new ArtifactsMmoApiClient(errorHandlerAdapter);
    }

    private HttpClient CreateHttpClient()
    {
        var client = httpClientFactory.CreateClient(ArtifactsMmoApiClientName);

        client.BaseAddress = new Uri(options.Value.BaseAddress ?? DefaultBaseAddress);
        client.DefaultRequestHeaders.Add("User-Agent",
            "ArtifactsMmoDotNet/1.0.0 (+https://github.com/ricardoboss/ArtifactsMmoDotNet)");
        client.Timeout = options.Value.Timeout ?? DefaultTimeout;

        return client;
    }
}
