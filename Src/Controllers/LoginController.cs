/// <summary>
/// Login API
/// </summary>
/// <remarks>
/// for user login, and generate JWT token
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 10/10/2024
/// </author>
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OXL_Assessment2.Src.Attributes;
using OXL_Assessment2.Src.Constants;
using OXL_Assessment2.Src.Data.Entities;
using OXL_Assessment2.Src.Models;
using OXL_Assessment2.Src.Utilities;

namespace OXL_Assessment2.Src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : AbstractBaseController
    {
        private readonly UserManager<NZTUser> _userManager;
        private readonly JwtTokenHelper _jwtTokenHelper;

        public LoginController(UserManager<NZTUser> userManager, JwtTokenHelper jwtTokenHelper)
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
        public async Task<IActionResult> Login(LoginModel loginModel)
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
                return Ok(CreateResponse<string>(ServiceCode.LoginSuccessful,
                MessageConstants.LoginSuccessful, token));
            }
            else return Unauthorized(CreateResponse(ServiceCode.PasswordNotCorrect,
            MessageConstants.PasswordNotCorrect));
        }
    }
}
