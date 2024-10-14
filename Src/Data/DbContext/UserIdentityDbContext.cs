/// <summary>
/// operate identity relavant data like user, role
/// </summary>
/// <remarks>
/// operate identity relavant data like user, role, follow rule of Identity framework
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 09/10/2024
/// </author>
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Data.DbContext;

public class UserIdentityDbContext : IdentityDbContext<KwtUser, KwtRole, long>
{
  public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options)
  {
  }
}
