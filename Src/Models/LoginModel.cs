/// <summary>
/// Unified format of login input
/// <param name="UserName"> user name from frontend
/// <param name="Password"> password from frontend
/// </summary>
/// <remarks>
/// Unified format of login input
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 08/10/2024
/// </author>
namespace OXL_Assessment2.Src.Models;

public record class LoginModel(string UserName, string Password);
