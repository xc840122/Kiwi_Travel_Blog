/// <summary>
/// registration api
/// </summary>
/// <remarks>
/// registration feature for normal user
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 09/10/2024
/// </author>
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OXL_Assessment2.Src.Attributes;
using OXL_Assessment2.Src.Constants;
using OXL_Assessment2.Src.Data.Entities;
using OXL_Assessment2.Src.Models;

namespace OXL_Assessment2.Src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : AbstractBaseController
    {
        private readonly UserManager<NZTUser> _userManager;
        public RegistrationController(UserManager<NZTUser> userManager)
        {
            this._userManager = userManager;
        }

        // normal user registration
        [ModelStateVerification]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel registerModel)
        {
            //API receives data (e.g., JSON) from a client, it binds that data to a model. 
            //Checking ModelState.IsValid ensures that the incoming data meets all validation 
            //rules defined in the model (e.g., data types, required fields).
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }
            // create EndUser
            var endUser = new NZTUser
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
            };
            // call UserManager method to create endUser
            var result = await _userManager.CreateAsync(endUser, registerModel.Password);
            // response
            if (result.Succeeded)
            {
                return Ok(CreateResponse<string>(ServiceCode.RegistrationSuccessful,
                MessageConstants.RegistrationSuccessful, endUser.UserName));
            }
            return BadRequest(CreateResponse<IEnumerable<IdentityError>>(ServiceCode.RegistrationFailed,
            MessageConstants.RegistrationFailed, result.Errors));
        }
    }
}
