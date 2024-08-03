using ArtifactsMmoDotNet.Api.Generated;
using ArtifactsMmoDotNet.Sdk.Interfaces.Factories;
using ArtifactsMmoDotNet.Sdk.Interfaces.Game;
using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;
using ArtifactsMmoDotNet.Sdk.Interfaces.Services;
using ArtifactsMmoDotNet.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions.Authentication;

namespace ArtifactsMmoDotNet.Sdk.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSingletonFactory<TFactory, TService>(this IServiceCollection services)
        where TFactory : IFactory<TService>
        where TService : class
    {
        return services.AddSingleton<TService>(sp => sp.GetRequiredService<TFactory>().Create());
    }

    public static IServiceCollection AddDefaultInteractiveLoginService(this IServiceCollection services)
    {
        return services.AddSingleton<IInteractiveLoginService, DefaultInteractiveLoginService>();
    }

    public static IServiceCollection AddDefaultLoginServiceFactory(this IServiceCollection services)
    {
        return services
            .AddSingleton<ILoginServiceFactory, DefaultLoginServiceFactory>()
            .AddSingletonFactory<ILoginServiceFactory, ILoginService>();
    }

    public static IServiceCollection AddDefaultTokenStorageFactory(this IServiceCollection services)
    {
        return services
            .AddSingleton<ITokenStorageFactory, DefaultTokenStorageFactory>()
            .AddSingletonFactory<ITokenStorageFactory, ITokenStorage>();
    }

    public static IServiceCollection AddApiLoginTokenGenerator(this IServiceCollection services)
    {
        return services.AddSingleton<ILoginTokenGenerator, ApiLoginTokenGenerator>();
    }

    public static IServiceCollection AddArtifactsMmoApiClient(this IServiceCollection services)
    {
        return services
            .AddHttpClient()
            .AddSingleton<IAccessTokenProvider, TokenStorageAccessTokenProvider>()
            .AddSingleton<IArtifactsMmoApiClientFactory, DefaultArtifactsMmoApiClientFactory>()
            .AddSingletonFactory<IArtifactsMmoApiClientFactory, ArtifactsMmoApiClient>();
    }

    public static IServiceCollection AddArtifactsMmoApiGame(this IServiceCollection services)
    {
        return services.AddSingleton<IGame, ArtifactsMmoApiGame>();
    }
}
