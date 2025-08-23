using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace ArtifactsMmoDotNet.Cli.Infrastructure;

internal sealed class ServiceCollectionTypeRegistrar(IServiceCollection builder)
    : ITypeRegistrar, ITypeRegistrarFrontend
{
    public void Register(Type service,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        Type implementation)
    {
        ArgumentNullException.ThrowIfNull(implementation);

        builder.AddSingleton(service, implementation);
    }

    public void RegisterInstance(Type service, object? implementation)
    {
        ArgumentNullException.ThrowIfNull(implementation);

        builder.AddSingleton(service, implementation);
    }

    public void RegisterLazy(Type service, Func<object> factory)
    {
        ArgumentNullException.ThrowIfNull(factory);

        builder.AddSingleton(service, factory);
    }

    public ITypeResolver Build() => new ServiceProviderTypeResolver(builder.BuildServiceProvider());

    public void Register<TService,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
    TImplementation>()
        where TImplementation : TService =>
        Register(typeof(TService), typeof(TImplementation));

    public void RegisterInstance<TImplementation>(TImplementation instance) =>
        RegisterInstance(typeof(TImplementation), instance);

    public void RegisterInstance<TService, TImplementation>(TImplementation instance)
        where TImplementation : TService => RegisterInstance<TService>(instance);
}
