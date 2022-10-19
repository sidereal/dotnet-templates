using MinimalApi.Services;
using Serilog;

namespace MinimalApi.ExtensionMethods;

public static partial class Extensions
{
    public static void BuildApiServices(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

        Log.Information("Starting up");

        builder.Host.UseSerilog((context, config) =>
            config.Enrich.FromLogContext()
            .ReadFrom.Configuration(context.Configuration)
            //.WriteTo.Console(outputTemplate: context.Configuration.GetValue<string>("Serilog:LogTemplate"))
            );

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<DemoService>();
        //builder.Services.AddTransient<DemoService>();
        builder.Services.AddTransient<ExceptionHandlerMiddleware>();

    }
}

