using ArtifactsMmoDotNet.Sdk.Interfaces;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class DefaultTokenStorageFactory : ITokenStorageFactory
{
    public ITokenStorage Create()
    {
        return new FileTokenStorage("token.txt");
    }
}
