namespace ArtifactsMmoDotNet.Sdk.Interfaces.Services;

public interface ITokenStorage
{
    Task<string?> GetTokenAsync();

    Task SetTokenAsync(string token);

    Task ClearTokenAsync();
}
