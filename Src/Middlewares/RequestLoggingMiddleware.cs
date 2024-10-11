using System;

namespace OXL_Assessment2.Src.Middlewares;

/// <summary>
/// log all request, for debug purpose
/// </summary>
public class RequestLoggingMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<RequestLoggingMiddleware> _logger;

  public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    // Log request details
    await LogRequest(context);

    // Call the next middleware in the pipeline
    await _next(context);
  }

  private async Task LogRequest(HttpContext context)
  {
    // Log the HTTP method and URL
    var method = context.Request.Method;
    var url = context.Request.Path;
    _logger.LogInformation("Incoming request: {Method} {Url}", method, url);

    // Log headers
    foreach (var header in context.Request.Headers)
    {
      _logger.LogInformation("Header: {HeaderKey}: {HeaderValue}", header.Key, header.Value);
    }

    // Log request body (if applicable and not too large)
    if (context.Request.ContentLength > 0 && context.Request.ContentType != null &&
        context.Request.ContentType.Contains("application/json"))
    {
      // Enable buffering so we can read the request body multiple times
      context.Request.EnableBuffering();

      // Read the request body
      var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
      context.Request.Body.Position = 0; // Reset the stream position so the next middleware can read it

      _logger.LogInformation("Request Body: {Body}", body);
    }
  }
}
