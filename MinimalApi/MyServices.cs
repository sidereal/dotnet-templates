using Serilog;

namespace MinimalApi
{
    public static class MyServices
    {
        public static void Build(WebApplicationBuilder builder)
        {

            builder.Logging.ClearProviders();
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
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
