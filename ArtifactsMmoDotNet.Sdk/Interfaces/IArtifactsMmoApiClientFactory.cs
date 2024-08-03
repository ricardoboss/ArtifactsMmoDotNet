using ArtifactsMmoDotNet.Api.Generated;

namespace ArtifactsMmoDotNet.Sdk.Interfaces;

public interface IArtifactsMmoApiClientFactory : IFactory<ArtifactsMmoApiClient>
{
    ArtifactsMmoApiClient CreateWithBasicAuth(string username, string password);
}
