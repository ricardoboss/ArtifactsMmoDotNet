using ArtifactsMmoDotNet.Sdk.Interfaces;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class DefaultLoginServiceFactory(ITokenStorageFactory tokenStorageFactory, ILoginTokenGenerator loginTokenGenerator) : ILoginServiceFactory
{
    public ILoginService Create()
    {
        var tokenStorage = tokenStorageFactory.Create();

        return new TokenLoginService(tokenStorage, loginTokenGenerator);
    }
}
