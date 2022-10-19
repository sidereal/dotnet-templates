namespace MinimalApi.ExtensionMethods;

public static partial class Extensions
{
    public static void BuildMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        app.UseMiddleware<DemoMiddleware>();

    }
}

