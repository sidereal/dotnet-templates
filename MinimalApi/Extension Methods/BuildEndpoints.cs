using MinimalApi.Endpoints;

namespace MinimalApi.ExtensionMethods;

public static partial class Extensions
{
    public static void BuildEndpoints(this WebApplication app)
    {
        // The standard MS demo endpoint
        app.MapGet("/weatherforecast", DemoEndpointHelpers.GetWeatherForecast).WithName("GetWeatherForecast");

        //Logger Factory & DummyService injected using DI
        //this would be async in a proper endpoint
        app.MapGet("/demo", DemoEndpointHelpers.GetDemo);

    }
}

