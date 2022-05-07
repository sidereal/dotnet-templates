using System.IO;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

using Sidereal.Executor;

var builder = new ConfigurationBuilder();
BuildConfig(builder);

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();


Log.Logger.Information("Launching");


var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
{
    services.AddSingleton<Executor>();

}).UseSerilog().Build();

//using (host)
//{
await host.StartAsync();

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

host.Dispose();
//}


static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
}