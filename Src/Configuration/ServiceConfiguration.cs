using System;
using Kiwi_Travel_Blog.Interface;
using Kiwi_Travel_Blog.Src.Services;
using Kiwi_Travel_Blog.Src.Services.IServices;

namespace Kiwi_Travel_Blog.Src.Configuration;

public class ServiceConfiguration : IAppConfigurationInterface
{
  public void ConfigureApp(IServiceCollection services)
  {
    // Add services
    services.AddScoped<ICategoryService, CategoryService>(); //category service
    services.AddScoped<IArticleService, ArticleService>(); //article service
  }
}
