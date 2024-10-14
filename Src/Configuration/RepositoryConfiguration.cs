using System;
using Kiwi_Travel_Blog.Interface.IServices;
using Kiwi_Travel_Blog.Src.Repositories;
using Kiwi_Travel_Blog.Src.Repositories.IRepositories;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// Configuration of Repository DI
/// </summary>
public class RepositoryConfiguration : IAppConfigurationInterface
{
  /// <summary>
  /// Configuration of Repository DI
  /// </summary>
  /// <param name="services"></param>
  public void ConfigureApp(IServiceCollection services)
  {
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<IArticleRepository, ArticleRepository>();
  }
}
