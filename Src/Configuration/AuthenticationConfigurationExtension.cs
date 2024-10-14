using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Kiwi_Travel_Blog.Src.Configuration;
/// <summary>
/// extension class for token and authentication configuration
/// </summary>
public static class AuthenticationConfigurationExtension
{
  /// <summary>
  /// extensive method to inject related services
  /// </summary>
  /// <param name="services"></param>
  /// <param name="configuration"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IServiceCollection InjectAuthenticationServices(IServiceCollection services, IConfiguration configuration)
  {
    // get key value from appsetting.json
    var jwtSettings = configuration.GetSection("JwtSettings");
    var key = jwtSettings["Key"];
    if (string.IsNullOrEmpty(key))
    {
      throw new ArgumentNullException("JWT Key is not configured properly.");
    }
    // token configuration, authentication configuration
    services
      .AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(options =>
      {
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          RequireExpirationTime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = jwtSettings["Issuer"],
          ValidAudience = jwtSettings["Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // //JWT cryptographic algorithms generally work with byte arrays.
        };
        // options.TokenValidationParameters.ValidateLifetime = false;  // For testing only
        // options.IncludeErrorDetails = true; //for debugging
      });
    return services;
  }
}
