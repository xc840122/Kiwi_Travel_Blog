using System;
using Kiwi_Travel_Blog.Interface;
using Kiwi_Travel_Blog.Src.Services;
using Kiwi_Travel_Blog.Src.Services.IServices;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// extension to inject business related logic
/// </summary>
public class BusinessConfigurationExtension
{
  /// <summary>
  /// extension method to inject business related logic
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public IServiceCollection InjectBusinessExtension(IServiceCollection services)
  {
    // Add services
    services.AddScoped<ICategoryService, CategoryService>(); //category service
    services.AddScoped<IArticleService, ArticleService>(); //article service

    return services;
  }
}
