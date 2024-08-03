using ArtifactsMmoDotNet.Sdk.Interfaces.Services;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class FileTokenStorage(string path) : ITokenStorage
{
    public async Task<string?> GetTokenAsync()
    {
        if (!File.Exists(path))
            return null;

        return await File.ReadAllTextAsync(path);
    }

    public async Task SetTokenAsync(string token)
    {
        await File.WriteAllTextAsync(path, token);
    }

    public Task ClearTokenAsync()
    {
        File.Delete(path);

        return Task.CompletedTask;
    }
}
