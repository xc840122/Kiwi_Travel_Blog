using System;
using Kiwi_Travel_Blog.Data;
using Kiwi_Travel_Blog.Src.Data.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// use extension method to inject all db related services
/// </summary>
public static class DatabaseConfigurationExtension
{
  /// <summary>
  /// extension method to inject db related services
  /// </summary>
  /// <param name="services"></param>
  /// <param name="configuration"></param>
  /// <returns></returns>
  public static IServiceCollection InjectDatabaseServices(this IServiceCollection services, IConfiguration configuration)
  {
    // Database configuration
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    // Identity db configuration
    services.AddDbContext<UserIdentityDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

    return services;
  }
}
