using System;
using Kiwi_Travel_Blog.Src.Data.DbContext;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// extension to inject identity related services
/// </summary>
public static class IdentityConfigurationExtension
{
  /// <summary>
  /// Inject identity services
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection InjectIdentityServices(this IServiceCollection services)
  {
    // Add Identity and JWT services
    services.AddIdentity<KwtUser, KwtRole>()
        .AddEntityFrameworkStores<UserIdentityDbContext>()
        .AddDefaultTokenProviders();

    // protect password, encryption
    services.AddDataProtection();
    // set the password policies
    services.AddIdentityCore<KwtUser>(options =>
    {
      options.Password.RequireDigit = false; //Disables the requirement for at least one numeric digit (0-9) in passwords.
      options.Password.RequireLowercase = false; //Disables the requirement for at least one lowercase letter (a-z) in passwords.
      options.Password.RequireNonAlphanumeric = false; //Disables the requirement for non-alphanumeric characters (e.g., @, #, $, etc.) in passwords.
      options.Password.RequireUppercase = false; //Disables the requirement for at least one uppercase letter (A-Z) in passwords.
      options.Password.RequiredLength = 6; //Sets the minimum length for passwords to 6 characters.
      options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider; //Specifies the token provider to be used for generating and validating password reset tokens. In this case, it uses the default email token provider, which generates tokens sent via email.
      options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider; //Specifies the token provider to be used for generating and validating email confirmation tokens, again using the default email provider.
    });
    return services;
  }
}
