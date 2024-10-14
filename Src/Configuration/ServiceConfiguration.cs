using System;
using Kiwi_Travel_Blog.Interface;
using Kiwi_Travel_Blog.Src.Services;
using Kiwi_Travel_Blog.Src.Services.IServices;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// Configuration of Service DI
/// </summary>
public class ServiceConfiguration : IAppConfigurationInterface
{
  /// <summary>
  /// Configuration of Service DI
  /// </summary>
  /// <param name="services"></param>
  public void ConfigureApp(IServiceCollection services)
  {
    // Add services
    services.AddScoped<ICategoryService, CategoryService>(); //category service
    services.AddScoped<IArticleService, ArticleService>(); //article service
  }
}
