using Spectre.Console.Cli;

namespace ArtifactsMmoDotNet.Cli.Infrastructure;

public sealed class ServiceProviderTypeResolver(IServiceProvider provider) : ITypeResolver, IServiceProvider, IDisposable
{
    public object? GetService(Type serviceType) => Resolve(serviceType);

    public object? Resolve(Type? type) => type == null ? null : provider.GetService(type);

    public void Dispose()
    {
        if (provider is IDisposable disposable)
            disposable.Dispose();
    }
}
