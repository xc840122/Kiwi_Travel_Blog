using System;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Models;

namespace Kiwi_Travel_Blog.Src.Utilities;
/// <summary>
/// Utility class to manage JSON web token
/// </summary>
public class JwtTokenHelper
{
  private readonly IConfiguration _configuration;
  private readonly ILogger<JwtTokenHelper> _logger;
  public JwtTokenHelper(IConfiguration configuration, ILogger<JwtTokenHelper> logger)
  {
    this._configuration = configuration;
    this._logger = logger;
  }

  /// <summary>
  /// Generate Json web token
  /// </summary>
  /// <param name="loginModel">passed from client</param>
  /// <returns></returns>
  public string GenerateJwtToken(LoginModel loginModel)
  {
    try
    {
      _logger.LogInformation("Generating JWT token for user: {UserName}", loginModel.UserName);
      // prepare value for token generation
      var jwtSettings = _configuration.GetSection("JwtSettings"); // get configuration of JWT from configuration file
      var key = jwtSettings["Key"]; //get the value of "Key" from configuration(appsetting.json)
      if (string.IsNullOrEmpty(key))
      {
        _logger.LogError("JWT Key is not configured.");
        throw new ArgumentNullException(MessageConstants.NotConfigureKey);
      }
      var expiredMins = Convert.ToInt64(jwtSettings["ExpiredMins"]); //configured expired mins, 5mins if null
      var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); // generate key
      var credential = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256); // generate credential with encryption algorithm

      // create claims 
      var claims = new[]{
      new Claim(ClaimTypes.Name, loginModel.UserName),
      new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //improve security, and support tracking or revocation mechanisms. It’s a good way to provide token uniqueness and guard against potential misuse.
    };
      // Initializes a new instance of the System.IdentityModel.Tokens.Jwt.JwtSecurityToken
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Issuer = jwtSettings["Issuer"],
        Audience = jwtSettings["Audience"],
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddMinutes(expiredMins),
        SigningCredentials = credential
      };

      // create token string
      var token = new JsonWebTokenHandler().CreateToken(tokenDescriptor);
      _logger.LogInformation("JWT token generated successfully for user: {UserName}", loginModel.UserName);
      return token;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error generating JWT token for user: {UserName}", loginModel.UserName);
      throw; // rethrow the exception after logging
    }
  }
}
