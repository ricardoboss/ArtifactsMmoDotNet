namespace ArtifactsMmoDotNet.Sdk.Interfaces;

public interface IInteractiveLoginService
{
    Task<bool> LoginWithUsernameAndPasswordAsync(string? username = null, string? password = null);
}