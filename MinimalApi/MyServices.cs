using Serilog;

namespace MinimalApi
{
    public static class MyServices
    {
        public static void BuildMyServices(this WebApplicationBuilder builder)
        {
            IConfiguration configSerilog = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", true, true)
             .Build();

            string logTemplate = "{NewLine}[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}";

            builder.Logging.ClearProviders();
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configSerilog)
                .WriteTo.Console(outputTemplate: logTemplate)
                .CreateLogger();

            builder.Logging.AddSerilog(logger);

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<DummyService>();

        }
    }
}
