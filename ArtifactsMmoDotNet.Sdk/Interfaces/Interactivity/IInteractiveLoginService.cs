namespace ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;

public interface IInteractiveLoginService
{
    Task<bool> LoginWithUsernameAndPasswordAsync(string? username = null, string? password = null);
}
