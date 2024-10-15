using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Kiwi_Travel_Blog.Src.Attributes;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// extension class to inject controller related service
/// </summary>
public static class ControllerConfigurationExtension
{
  /// <summary>
  /// extensive method to inject controller related service and filters
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection InjectControllerServices(this IServiceCollection services)
  {
    // Add controller with options (filters...etc.)
    services.AddControllers(options =>
        {
          options.Filters.Add<ModelStateVerificationAttribute>(); // register the attribute
        })
        .AddJsonOptions(options =>
        {
          options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // Adjust as necessary
          options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

    return services;
  }
}
