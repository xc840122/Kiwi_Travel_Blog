using System;
using OXL_Assessment2.Interface;
using OXL_Assessment2.Src.Services;
using OXL_Assessment2.Src.Services.IServices;

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
