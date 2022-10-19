using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace MinimalApi;

/// <summary>
/// Implements IMiddleware.
/// Requires injection as a service prior to being called (See BuildApiServices helper method).
/// Has a different method signatures to duck typed middleware
/// </summary>
public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger) => _logger = logger;


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
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Server Error",
                Title = "Server Error",
                Detail = $"Exception Handled by {GetType().Name}: {ex.Message}"
            };

            string json = JsonSerializer.Serialize(problem);
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}
