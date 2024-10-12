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
namespace OXL_Assessment2.Src.Data.Entities;

public class NZTUser : IdentityUser<long>
{

}
