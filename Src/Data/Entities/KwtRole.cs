using System;
using Microsoft.AspNetCore.Identity;
/// <summary>
/// role entity
/// </summary>
/// <remarks>
/// role engity inherits from IdentityRole<>, normal user and administrator
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 09/10/2024
/// </author>
namespace Kiwi_Travel_Blog.Src.Data.Entities;

public class KwtRole : IdentityRole<long>
{

}
