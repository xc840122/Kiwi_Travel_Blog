/// <summary>
/// Unified format of new user registration
/// <param name="UserName"> user name from frontend
/// <param name="Password"> password from frontend
/// <param name="Email">email from frontend
/// </summary>
/// <remarks>
/// Unified format of new user registration
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 08/10/2024
/// </author>
using System;

namespace Kiwi_Travel_Blog.Src.Models;

public record RegisterModel(string UserName, string Email, string Password);

