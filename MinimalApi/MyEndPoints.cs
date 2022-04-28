namespace MinimalApi
{
    public static class MyEndPoints
    {
        static string[] _summaries = { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        public static void BuildMyEndpoints(this WebApplication app)
        {

            // The standard MS demo endpoint
            app.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                   new WeatherForecast
                   (
                       DateTime.Now.AddDays(index),
                       Random.Shared.Next(-20, 55),
                       _summaries[Random.Shared.Next(_summaries.Length)]
                   ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");


            //Logger Factory & DummyService injected using DI
            //this would be async in a proper endpoint
            app.MapGet("/dummy", (ILoggerFactory loggerFactory, DummyService ds) =>
            {
                string message = "hello";

                //if you need a logger in your endpoint
                var logger = loggerFactory.CreateLogger("dummy");
                logger.LogInformation("Logged in endpoint {message}", message);

                //using the injected service
                ds.DoSomething(message);
                return Results.Ok(message);
            });
        }
    }

    internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

}
