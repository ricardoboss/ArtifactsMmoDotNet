using ArtifactsMmoDotNet.Sdk.Exceptions;

namespace ArtifactsMmoDotNet.Sdk.Interfaces.Services;

public interface ILoginTokenGenerator
{
    /// <exception cref="LoginFailureException">If the login fails.</exception>
    Task<string> GetTokenAsync(string username, string password);
}
