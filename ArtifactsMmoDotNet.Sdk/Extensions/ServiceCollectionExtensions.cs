using System.Diagnostics.CodeAnalysis;
using ArtifactsMmoDotNet.Api.Generated;
using ArtifactsMmoDotNet.Sdk.Interfaces.Factories;
using ArtifactsMmoDotNet.Sdk.Interfaces.Game;
using ArtifactsMmoDotNet.Sdk.Interfaces.Interactivity;
using ArtifactsMmoDotNet.Sdk.Interfaces.Services;
using ArtifactsMmoDotNet.Sdk.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

    private const string RequiresDynamicCodeMessage =
        "Binding strongly typed objects to configuration values may require generating dynamic code at runtime.";

    private const string TrimmingRequiredUnreferencedCodeMessage =
        "TOptions's dependent types may have their members trimmed. Ensure all required members are preserved.";

    [RequiresDynamicCode(RequiresDynamicCodeMessage)]
    [RequiresUnreferencedCode(TrimmingRequiredUnreferencedCodeMessage)]
    public static IServiceCollection AddArtifactsMmoApiClient(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services.AddArtifactsMmoApiClient(o => o.Bind(configuration));
    }

    [RequiresDynamicCode(RequiresDynamicCodeMessage)]
    [RequiresUnreferencedCode(TrimmingRequiredUnreferencedCodeMessage)]
    public static IServiceCollection AddArtifactsMmoApiClient(this IServiceCollection services,
        string configurationSectionName)
    {
        return services.AddArtifactsMmoApiClient(o => o.BindConfiguration(configurationSectionName));
    }

    public static IServiceCollection AddArtifactsMmoApiClient(this IServiceCollection services,
        Action<ArtifactsMmoApiClientOptions> configureOptions)
    {
        return services.AddArtifactsMmoApiClient(o => o.Configure(configureOptions));
    }

    public static IServiceCollection AddArtifactsMmoApiClient(this IServiceCollection services)
    {
        return services.AddArtifactsMmoApiClient((Action<OptionsBuilder<ArtifactsMmoApiClientOptions>>)(_ => { }));
    }

    private static IServiceCollection AddArtifactsMmoApiClient(this IServiceCollection services,
        Action<OptionsBuilder<ArtifactsMmoApiClientOptions>> configureOptions)
    {
        var optionsBuilder = services.AddOptions<ArtifactsMmoApiClientOptions>();

        configureOptions(optionsBuilder);

        optionsBuilder.ValidateOnStart();

        services.AddHttpClient(DefaultArtifactsMmoApiClientFactory.ArtifactsMmoApiClientName);

        return services
            .AddSingleton<IAccessTokenProvider, TokenStorageAccessTokenProvider>()
            .AddSingleton<IArtifactsMmoApiClientFactory, DefaultArtifactsMmoApiClientFactory>()
            .AddSingletonFactory<IArtifactsMmoApiClientFactory, ArtifactsMmoApiClient>();
    }

    public static IServiceCollection AddArtifactsMmoApiGame(this IServiceCollection services)
    {
        return services.AddSingleton<IGame, ArtifactsMmoApiGame>();
    }
}
