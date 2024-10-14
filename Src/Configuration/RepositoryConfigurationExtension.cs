using System;
using Kiwi_Travel_Blog.Interface.IServices;
using Kiwi_Travel_Blog.Src.Repositories;
using Kiwi_Travel_Blog.Src.Repositories.IRepositories;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// extension class to inject repository related services
/// </summary>
public static class RepositoryConfigurationExtension
{
  /// <summary>
  /// extension method to inject db related services
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection InjectRepositoryServices(this IServiceCollection services)
  {
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<IArticleRepository, ArticleRepository>();

    return services;
  }
}
