
/// <summary>
/// Middleware to generate request ID
/// </summary>
/// <remarks>
/// Generate request ID for each http request
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 09/10/2024
/// </author>
using System;

namespace OXL_Assessment2.Src.Middlewares;

public class RequestIdMiddleware
{
  private readonly RequestDelegate _next;

  public RequestIdMiddleware(RequestDelegate next)
  {
    this._next = next;
  }

  public async Task InvokeAsync(HttpContext httpContext)
  {
    // generate unique request ID
    var requestId = Guid.NewGuid().ToString();

    // add id to request items
    httpContext.Items["RequestId"] = requestId;

    // add id to response header
    httpContext.Response.Headers.Append("X-Request-ID", requestId);

    // continue with request pipeline
    await _next(httpContext);
  }
}
