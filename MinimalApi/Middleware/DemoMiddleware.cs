namespace MinimalApi;


/// <summary>
/// Duck typed middleware.
/// Does not require injection as a service prior to being called.
/// Has a different method signatures to middleware implementing Imiddleware.
/// </summary>

public class DemoMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<DemoMiddleware> _logger;

    public DemoMiddleware(RequestDelegate next, ILogger<DemoMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var name = GetType().Name;
        _logger.LogInformation("Request: Activity logged in middleware {name}", name);
        await _next(context);
        _logger.LogInformation("Response: Activity logged in middleware {name}", name);
    }
}




