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
namespace Kiwi_Travel_Blog.Src.Models;

public record class LoginModel(string UserName, string Password);
