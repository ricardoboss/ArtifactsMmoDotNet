namespace ArtifactsMmoDotNet.Sdk.Interfaces;

public interface ITokenStorage
{
    Task<string?> GetTokenAsync();

    Task SetTokenAsync(string token);

    Task ClearTokenAsync();
}
