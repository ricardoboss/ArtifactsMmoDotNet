namespace ArtifactsMmoDotNet.Sdk.Interfaces.Services;

public interface ILoginService
{
    Task<bool> IsLoggedInAsync();

    Task LoginAsync(string username, string password);

    Task LogoutAsync();
}
