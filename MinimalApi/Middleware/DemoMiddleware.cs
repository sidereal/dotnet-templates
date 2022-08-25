namespace MinimalApi;

public class DemoMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<DemoMiddleware> _logger;

    public DemoMiddleware(RequestDelegate next, ILogger<DemoMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var name = GetType().Name;
        _logger.LogInformation("Activity logged in middleware {name}", name);
        await _next(httpContext);
    }
}




