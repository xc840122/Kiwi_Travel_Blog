using System;
using Kiwi_Travel_Blog.Src.Utilities;

namespace Kiwi_Travel_Blog.Src.Configuration;

public class UtilityConfiguration : IAppConfigurationInterface
{
  public void ConfigureApp(IServiceCollection services)
  {
    // Add Jwt helper
    services.AddScoped<JwtTokenHelper>();
  }
}
