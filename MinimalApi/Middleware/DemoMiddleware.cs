using System.Net;

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
        _logger.LogInformation("hello from middleware!");
        await _next(httpContext);
    }
}




