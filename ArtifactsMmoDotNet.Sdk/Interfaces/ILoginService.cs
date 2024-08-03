namespace ArtifactsMmoDotNet.Sdk.Interfaces;

public interface ILoginService
{
    Task<bool> IsLoggedInAsync();

    Task LoginAsync(string username, string password);

    Task LogoutAsync();
}
