using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

using Sidereal.Executor;


Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

Log.Information("Starting up");

var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
{
    services.AddSingleton<Executor>();

}).UseSerilog(
    (context, config) =>
                config.Enrich.FromLogContext()
                .ReadFrom.Configuration(context.Configuration)
    ).Build();

await host.StartAsync();

Log.Information("Host Started");

var executor = host.Services.GetRequiredService<Executor>();
await executor.RunAsync();
executor.Run();

//var executor = ActivatorUtilities.CreateInstance<Executor>(host.Services);
//await executor.RunAsync();
//executor.Run();

//wait for ctrl+c
await host.WaitForShutdownAsync();

Log.Logger.Information("Closing");
Log.CloseAndFlush();