using System;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// Interface for Configuratoin
/// </summary>
public interface IAppConfigurationInterface
{
  void ConfigureApp(IServiceCollection services);
}
