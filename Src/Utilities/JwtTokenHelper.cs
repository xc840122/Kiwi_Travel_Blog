using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OXL_Assessment2.Src.Constants;
using OXL_Assessment2.Src.Data.Entities;
using OXL_Assessment2.Src.Models;

namespace OXL_Assessment2.Src.Utilities;
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
      var keyValue = jwtSettings["Key"]; //get the value of "Key" from configuration(appsetting.json)
      if (string.IsNullOrEmpty(keyValue))
      {
        _logger.LogError("JWT Key is not configured.");
        throw new ArgumentNullException(MessageConstants.NotConfigureKey);
      }
      var expiredMins = Convert.ToInt64(jwtSettings["ExpiredMins"]); //configured expired mins, 5mins if null
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue)); // generate key
      var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // generate credential with encryption algorithm

      // create claims 
      var claims = new[]{
      new Claim(JwtRegisteredClaimNames.Sub, loginModel.UserName),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //improve security, and support tracking or revocation mechanisms. It’s a good way to provide token uniqueness and guard against potential misuse.
    };

      // Initializes a new instance of the System.IdentityModel.Tokens.Jwt.JwtSecurityToken
      var token = new JwtSecurityToken(
              issuer: jwtSettings["Issuer"],
              audience: jwtSettings["Audience"],
              claims: claims,
              expires: DateTime.UtcNow.AddMinutes(expiredMins), //expired duration
              signingCredentials: credential);

      // create token string
      var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
      _logger.LogInformation("JWT token generated successfully for user: {UserName}", loginModel.UserName);
      return tokenString;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error generating JWT token for user: {UserName}", loginModel.UserName);
      throw; // rethrow the exception after logging
    }
  }
}
