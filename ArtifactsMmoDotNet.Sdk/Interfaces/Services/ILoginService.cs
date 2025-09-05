namespace ArtifactsMmoDotNet.Sdk.Interfaces.Services;

public interface ILoginService
{
    Task<bool> IsLoggedInAsync(CancellationToken cancellationToken = default);

    Task LoginAsync(string username, string password, CancellationToken cancellationToken = default);

    Task LogoutAsync(CancellationToken cancellationToken = default);
}
