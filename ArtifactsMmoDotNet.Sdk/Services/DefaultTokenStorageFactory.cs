using ArtifactsMmoDotNet.Sdk.Interfaces.Factories;
using ArtifactsMmoDotNet.Sdk.Interfaces.Services;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class DefaultTokenStorageFactory : ITokenStorageFactory
{
    public ITokenStorage Create()
    {
        return new FileTokenStorage("token.txt");
    }
}
