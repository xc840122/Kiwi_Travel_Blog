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

  public JwtTokenHelper(IConfiguration configuration)
  {
    this._configuration = configuration;
  }

  /// <summary>
  /// Generate Json web token
  /// </summary>
  /// <param name="loginModel">passed from client</param>
  /// <returns></returns>
  public string GenerateJwtToken(LoginModel loginModel)
  {
    var jwtSettings = _configuration.GetSection("JwtSettings"); // get configuration of JWT from configuration file
    var keyValue = jwtSettings["Key"]; //get the value of "Key" from configuration(appsetting.json)
    if (string.IsNullOrEmpty(keyValue))
    {
      throw new ArgumentNullException(MessageConstants.NotConfigureKey);
    }
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue)); // generate key
    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // generate credential with encryption algorithm

    // create claims 
    var claims = new[]{
      new Claim(JwtRegisteredClaimNames.Sub, loginModel.UserName),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //improve security, and support tracking or revocation mechanisms. It’s a good way to provide token uniqueness and guard against potential misuse.
    };

    // instantiate token, set token
    var token = new JwtSecurityToken(
            issuer: jwtSettings["Chi"],
            audience: jwtSettings["EndUser"],
            claims: claims,
            expires: DateTime.Now.AddDays(1), //expired duration
            signingCredentials: credential);

    // return token
    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
