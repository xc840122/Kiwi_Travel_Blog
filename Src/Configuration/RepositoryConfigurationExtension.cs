using System;
using Kiwi_Travel_Blog.Src.Repositories.AdminImpl;
using Kiwi_Travel_Blog.Src.Repositories.IAdminRepositories;
using Kiwi_Travel_Blog.Src.Repositories.IUserRepositories;
using Kiwi_Travel_Blog.Src.Repositories.UserImpl;

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
    services.AddScoped<IUserCategoryRepository, UserCategoryRepository>();
    services.AddScoped<IUserArticleRepository, UserArticleRepository>();
    services.AddScoped<IAdminCategoryRepository, AdminCategoryRepository>();

    return services;
  }
}
