using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace MinimalApi;

/// <summary>
/// Implements IMiddleware.
/// Requires injection as a service prior to being called (See BuildApiServices extension method).
/// Has a different method signatures to duck typed middleware
/// </summary>
public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    private readonly IConfiguration _configuration;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            var name = GetType().Name;
            _logger.LogInformation("Request: Activity logged in middleware {name}", name);
            await next(context);
            _logger.LogInformation("Response: Activity logged in middleware {name}", name);
        }
        catch (Exception ex)
        {
            //Do we hide the exception from the client or expose it?
            bool exposeException = _configuration.GetValue<bool>("Application:ExposeExceptionsToClient");
            string detail = exposeException ? $"Exception Handled by {GetType().Name}: {ex.Message}" : "An error has occured. Contact support.";

            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Server Error",
                Title = "Server Error",
                Detail = detail
            };

            string json = JsonSerializer.Serialize(problem);
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}
