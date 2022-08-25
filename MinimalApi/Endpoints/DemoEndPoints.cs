using MinimalApi.Demo;
using MinimalApi.Helpers;

namespace MinimalApi.Endpoints
{
    public static class DemoEndPoints
    {


        public static void BuildDemoEndpoints(this WebApplication app)
        {

            // The standard MS demo endpoint
            app.MapGet("/weatherforecast", EndpointHelpers.GetWeatherForecast).WithName("GetWeatherForecast");

            //Logger Factory & DummyService injected using DI
            //this would be async in a proper endpoint
            app.MapGet("/demo", EndpointHelpers.GetDemo);
        }
    }
}
