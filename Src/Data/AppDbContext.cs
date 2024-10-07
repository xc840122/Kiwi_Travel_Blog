/// <summary>
/// managing the interaction between your application and the database
/// </summary>
/// <remarks>
/// managing the interaction between your application and the database
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 06/10/2024
/// </author>
using System;
using Microsoft.EntityFrameworkCore;
using OXL_Assessment2.Data.Configurations;
using OXL_Assessment2.Data.Entities;

namespace OXL_Assessment2.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  public DbSet<Category> Categories { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    // all configuration in this assembly
    modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    // modelBuilder.ApplyConfiguration(new CategoryConfiguration());
  }

  // auto track update and create
  public override int SaveChanges()
  {
    var entries = ChangeTracker
      .Entries()
      .Where(e => e.Entity is BaseEntity && (
          e.State == EntityState.Added
          || e.State == EntityState.Modified));

    foreach (var entityEntry in entries)
    {
      ((BaseEntity)entityEntry.Entity).CreateTime = DateTime.UtcNow;

      if (entityEntry.State == EntityState.Added)
      {
        ((BaseEntity)entityEntry.Entity).UpdateTime = DateTime.UtcNow;
      }
    }
    return base.SaveChanges();
  }
  // auto track update and create
  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    var entries = ChangeTracker
    .Entries()
    .Where(e => e.Entity is BaseEntity && (
        e.State == EntityState.Added
        || e.State == EntityState.Modified));

    foreach (var entityEntry in entries)
    {
      ((BaseEntity)entityEntry.Entity).CreateTime = DateTime.UtcNow;

      if (entityEntry.State == EntityState.Added)
      {
        ((BaseEntity)entityEntry.Entity).UpdateTime = DateTime.UtcNow;
      }
    }
    return base.SaveChangesAsync(cancellationToken);
  }
}
