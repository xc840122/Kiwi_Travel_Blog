using System;
using Kiwi_Travel_Blog.Src.Businesses.AdminImpl;
using Kiwi_Travel_Blog.Src.Businesses.IAdminBusinesses;
using Kiwi_Travel_Blog.Src.Businesses.IUserBusinesses;
using Kiwi_Travel_Blog.Src.Businesses.UserImpl;

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
    services.AddScoped<IAdminCategoryBusiness, AdminCategoryBusiness>();

    return services;
  }
}
