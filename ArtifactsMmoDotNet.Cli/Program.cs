using ArtifactsMmoDotNet.Api.Exceptions.Account;
using ArtifactsMmoDotNet.Cli.Commands;
using ArtifactsMmoDotNet.Cli.Extensions;
using ArtifactsMmoDotNet.Cli.Infrastructure;
using ArtifactsMmoDotNet.Sdk.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;

var services = new ServiceCollection();

ConfigureServices(services);

var registrar = new ServiceCollectionTypeRegistrar(services);
var app = new CommandApp<InteractiveCommand>(registrar);

app.Configure(ConfigureApp);

return await app.RunAsync(args);

void ConfigureApp(IConfigurator config)
{
    config.SetApplicationName("Artifacts MMO CLI");

#if DEBUG
    config.PropagateExceptions();
#else
    config.SetExceptionHandler(HandleException);
#endif

    config.AddCommand<LoginCommand>("login");
    config.AddCommand<MoveCommand>("move");
    config.AddCommand<InteractiveCommand>("interactive");
}

void ConfigureServices(IServiceCollection s)
{
    s.AddDefaultTokenStorageFactory();
    s.AddDefaultLoginServiceFactory();
    s.AddDefaultInteractiveLoginService();

    s.AddArtifactsMmoApiClient(o => o.BaseAddress = "https://api.artifactsmmo.com/");
    s.AddApiLoginTokenGenerator();

    s.AddArtifactsMmoApiGame();

    s.AddAnsiConsoleOutput();
    s.AddAnsiConsoleInputRequester();
}

#if !DEBUG
void HandleException(Exception ex, ITypeResolver? resolver)
{
    switch (ex)
    {
        case TokenExpiredException:
            AnsiConsole.MarkupLine(
                "[red]Your token expired. Please log in again using the [yellow]login[/] command.[/]");
            break;
        default:
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
            return;
    }

    AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
}
#endif
