namespace ArtifactsMmoDotNet.Sdk.Interfaces.Services;

public interface ITokenStorage
{
    Task<string?> GetTokenAsync(CancellationToken cancellationToken = default);

    Task SetTokenAsync(string token, CancellationToken cancellationToken = default);

    Task ClearTokenAsync(CancellationToken cancellationToken = default);
}
