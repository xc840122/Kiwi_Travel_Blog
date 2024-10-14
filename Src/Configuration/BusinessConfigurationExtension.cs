using System;
using Kiwi_Travel_Blog.Interface;
using Kiwi_Travel_Blog.Src.Businesses.IArticleBusiness;
using Kiwi_Travel_Blog.Src.Services;
using Kiwi_Travel_Blog.Src.Services.IServices;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// extension to inject business related logic
/// </summary>
public static class BusinessConfigurationExtension
{
  /// <summary>
  /// extension method to inject business related logic
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection InjectBusinessServices(this IServiceCollection services)
  {
    // Add services
    services.AddScoped<IUserCategoryBusiness, UserCategoryBusiness>(); //category service
    services.AddScoped<IUserArticleBusiness, UserArticleBusiness>(); //article service

    return services;
  }
}
