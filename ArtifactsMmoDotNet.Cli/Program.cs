using ArtifactsMmoDotNet.Cli.Commands;
using ArtifactsMmoDotNet.Cli.Extensions;
using ArtifactsMmoDotNet.Cli.Infrastructure;
using ArtifactsMmoDotNet.Sdk.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

var services = new ServiceCollection();

ConfigureServices(services);

var registrar = new ServiceCollectionTypeRegistrar(services);
var app = new CommandApp<InteractiveCommand>(registrar);

app.Configure(config =>
{
    config.SetApplicationName("Artifacts MMO CLI");

#if DEBUG
    config.PropagateExceptions();
#endif

    config.AddCommand<LoginCommand>("login");
    config.AddCommand<MoveCommand>("move");
    config.AddCommand<InteractiveCommand>("interactive");
});

return await app.RunAsync(args);

void ConfigureServices(IServiceCollection s)
{
    s.AddDefaultTokenStorageFactory();
    s.AddDefaultLoginServiceFactory();
    s.AddDefaultInteractiveLoginService();

    s.AddArtifactsMmoApiClient();
    s.AddApiLoginTokenGenerator();

    s.AddArtifactsMmoApiGame();

    s.AddAnsiConsoleOutput();
    s.AddAnsiConsoleInputRequester();
}
