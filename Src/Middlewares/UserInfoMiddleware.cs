using System;
using System.Security.Claims;

namespace Kiwi_Travel_Blog.Src.Middlewares;
/// <summary>
/// Fetch user information from JWT in http request
/// </summary>
public class UserInfoMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<UserInfoMiddleware> _logger;

  public UserInfoMiddleware(RequestDelegate next, ILogger<UserInfoMiddleware> logger)
  {
    this._next = next;
    this._logger = logger;
  }
  /// <summary>
  /// verify JWT, set username
  /// </summary>
  /// <param name="context"></param>
  /// <returns></returns>
  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      _logger.LogInformation("Retrieving user information fro requests...");

      // get UserIdentity
      var userIdentity = context.User.Identity;
      if (userIdentity != null && userIdentity.IsAuthenticated)
      {
        var userName = context.User.FindFirst(ClaimTypes.Name)?.Value;
        // add userName into items of http
        context.Items["UserName"] = userName;

        _logger.LogInformation("Username : {}", userName);
      }
      else
      {
        _logger.LogWarning("Getting user identity failed...");
      }

      // move to next action
      await _next(context);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "An error happend while retrieving user information");
    }
  }
}
