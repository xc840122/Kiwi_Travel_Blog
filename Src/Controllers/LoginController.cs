using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Models;
using Kiwi_Travel_Blog.Src.Utilities;

namespace Kiwi_Travel_Blog.Src.Controllers;
/// <summary>
/// Login controller
/// </summary>
[Route("api")]
[ApiController]
public class LoginController : AbstractBaseController
{
    private readonly UserManager<KwtUser> _userManager;
    private readonly JwtTokenHelper _jwtTokenHelper;

    public LoginController(UserManager<KwtUser> userManager, JwtTokenHelper jwtTokenHelper)
    {
        this._userManager = userManager;
        this._jwtTokenHelper = jwtTokenHelper;
    }

    /// <summary>
    /// normal user login
    /// </summary>
    /// <param name="loginModel"></param>
    /// <returns></returns>
    [ModelStateVerification]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        // try to get user from database by applying UserManager
        var user = await _userManager.FindByNameAsync(loginModel.UserName);
        // check if user exists
        if (user == null)
        {
            return NotFound(CreateResponse(ServiceCode.UserNotExist,
            MessageConstants.UserNotExist));
        }
        // check the password by UserManager
        bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginModel.Password);
        if (isPasswordCorrect)
        {
            var token = _jwtTokenHelper.GenerateJwtToken(loginModel);
            return Ok(CreateResponse<string>(ServiceCode.LoginSuccessfully,
            MessageConstants.LoginSuccessfully, token));
        }
        else return Unauthorized(CreateResponse(ServiceCode.PasswordNotCorrect,
        MessageConstants.PasswordNotCorrect));
    }
}

