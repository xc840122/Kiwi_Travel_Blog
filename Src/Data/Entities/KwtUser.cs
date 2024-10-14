using System;
using Microsoft.AspNetCore.Identity;
/// <summary>
/// user entity
/// </summary>
/// <remarks>
/// user engity inherits from IdentityUser<>
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 09/10/2024
/// </author>
namespace Kiwi_Travel_Blog.Src.Data.Entities;

public class KwtUser : IdentityUser<long>
{

}
