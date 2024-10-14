using System;
using Kiwi_Travel_Blog.Src.Utilities;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// 
/// </summary>
public static class UtilityConfigurationExtension
{
  public static IServiceCollection InjectUtilityExtension(this IServiceCollection services)
  {
    // Add Jwt helper
    services.AddScoped<JwtTokenHelper>();

    return services;
  }
}
