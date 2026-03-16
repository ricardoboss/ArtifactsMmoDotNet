using ArtifactsMmoDotNet.Api.Generated;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Store;

namespace ArtifactsMmoDotNet.Api;

public sealed class DisposableArtifactsMmoApiClient(IRequestAdapter requestAdapter)
    : ArtifactsMmoApiClient(requestAdapter), IDisposable
{
    public void Dispose()
    {
        if (RequestAdapter is IDisposable d)
            d.Dispose();
    }
}
