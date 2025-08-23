using ArtifactsMmoDotNet.Api.Generated;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Store;

namespace ArtifactsMmoDotNet.Api;

public sealed class DisposableArtifactsMmoApiClient(
    IRequestAdapter requestAdapter,
    IBackingStoreFactory? backingStore = null)
    : ArtifactsMmoApiClient(requestAdapter, backingStore), IDisposable
{
    public void Dispose()
    {
        if (RequestAdapter is IDisposable d)
            d.Dispose();
    }
}
