using System;
using Kiwi_Travel_Blog.Src.Utilities;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// extension class for utility configuration
/// </summary>
public static class UtilityConfigurationExtension
{
  /// <summary>
  /// extensive method to inject JWT services
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection InjectUtilityServices(this IServiceCollection services)
  {
    // Add Jwt helper
    services.AddScoped<JwtTokenHelper>();

    return services;
  }
}
