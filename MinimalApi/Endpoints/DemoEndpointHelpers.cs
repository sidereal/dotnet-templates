using MinimalApi.Services;
using System.Reflection;

namespace MinimalApi.Endpoints;

public static class DemoEndpointHelpers
{
    static string[] _summaries = { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    public static WeatherForecast[]? GetWeatherForecast()
    {
        WeatherForecast[] forecast = Enumerable.Range(1, 5).Select(index =>
                   new WeatherForecast
                   (
                       DateTime.Now.AddDays(index),
                       Random.Shared.Next(-20, 55),
                       _summaries[Random.Shared.Next(_summaries.Length)]
                   ))
                    .ToArray();
        return forecast;
    }

    public static IResult GetDemo(ILoggerFactory loggerFactory, DemoService ds)
    {
        var method = MethodBase.GetCurrentMethod();

        string message = "hello";

        //if you need a logger in your endpoint
        var logger = loggerFactory.CreateLogger("Demo-Endpoint-Logger");
        logger.LogInformation("Activity logged in endpoint helper class {name}", method?.Name);

        //using the injected service
        ds.DoSomething(message);
        return Results.Ok(message);
    }
}

public record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}