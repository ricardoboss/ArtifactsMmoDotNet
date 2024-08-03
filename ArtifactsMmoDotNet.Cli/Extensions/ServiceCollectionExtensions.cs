using ArtifactsMmoDotNet.Cli.Services;
using ArtifactsMmoDotNet.Sdk.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMmoDotNet.Cli.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAnsiConsoleOutput(this IServiceCollection services)
    {
        return services.AddSingleton<IOutput, AnsiConsoleOutput>();
    }
    
    public static IServiceCollection AddAnsiConsoleInputRequester(this IServiceCollection services)
    {
        return services.AddSingleton<IInputRequester, AnsiConsoleInputRequester>();
    }
}
