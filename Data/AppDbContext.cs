using System;
using Microsoft.EntityFrameworkCore;
using OXL_Assessment2.Data.Configurations;
using OXL_Assessment2.Data.Entities;

namespace OXL_Assessment2.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Category> Categories { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    // all configuration in this assembly
    // modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
  }

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
}
