using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

using Sidereal.Executor;
using System;
using System.Threading;

Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

Log.Information("Starting up");

using var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
{
    services.AddSingleton<Executor>();

}).UseSerilog(
    (context, config) =>
                config.Enrich.FromLogContext()
                .ReadFrom.Configuration(context.Configuration)
    ).Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;
Log.Information("Host Started");

//Console.CancelKeyPress += new ConsoleCancelEventHandler(cancelHandler);



try
{
    var executor = services.GetRequiredService<Executor>();
    var countTask = executor.RunAsync(5);
    
    executor.Run();
    //await Task.Delay(3500);
    //executor.Throw();
    await countTask;
    //await services.GetRequiredService<Executor>().RunAsync(5);
}
catch (Exception ex)
{
    Log.Logger.Error(ex, ex.Message);
}
finally
{
    scope.Dispose();
    Log.Logger.Information("Closing");
    Log.CloseAndFlush();
}

//host.WaitForShutdown();
//Log.Logger.Information("Shutdown");
//Log.CloseAndFlush();

//static void cancelHandler(object sender, ConsoleCancelEventArgs args)
//{
//    args.Cancel = true;
//    Log.Logger.Information("CANCEL command received! Cleaning up. please wait...");
//}