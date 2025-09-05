using ArtifactsMmoDotNet.Sdk.Interfaces.Services;

namespace ArtifactsMmoDotNet.Sdk.Services;

public class FileTokenStorage(string path) : ITokenStorage
{
    public async Task<string?> GetTokenAsync(CancellationToken cancellationToken = default)
    {
        if (!File.Exists(path))
            return null;

        return await File.ReadAllTextAsync(path, cancellationToken);
    }

    public async Task SetTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        await File.WriteAllTextAsync(path, token, cancellationToken);
    }

    public Task ClearTokenAsync(CancellationToken cancellationToken = default)
    {
        File.Delete(path);

        return Task.CompletedTask;
    }
}
