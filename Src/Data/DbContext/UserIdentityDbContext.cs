using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Data.DbContext;
/// <summary>
/// Identity database context
/// </summary>
public class UserIdentityDbContext : IdentityDbContext<KwtUser, KwtRole, long>
{
  public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options)
  {
  }
}
