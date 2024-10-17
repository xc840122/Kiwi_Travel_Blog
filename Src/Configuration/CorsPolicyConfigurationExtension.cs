using System;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// Extension for Cors(Cross-Origin Resource Sharing) policy configuration
/// </summary>
public static class CorsPolicyConfigurationExtension
{
  /// <summary>
  /// extensive method to inject Cors policy
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection InjectCorsPolicyServices(this IServiceCollection services)
  {
    services.AddCors(options =>
    {
      // Allow all for testing purpose
      options.AddPolicy("AllowAll",
          policy =>
          {
            policy.AllowAnyOrigin() // Allows any origin
                    .AllowAnyHeader()
                    .AllowAnyMethod();
          });
    });
    return services;
  }
}
