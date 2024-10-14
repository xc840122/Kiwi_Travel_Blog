using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kiwi_Travel_Blog.Data.Entities;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Data.Configurations;
/// <summary>
/// Configuration of category table
/// </summary>
/// <remarks>
/// 
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 06/10/2024
/// </author>
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.ToTable("T_Categories");
    builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
    builder.Property(e => e.Description).IsRequired();
    builder.HasMany<Article>(c => c.Articles).WithOne(a => a.Category).IsRequired();

    // Add index, unique
    builder.HasIndex(e => e.Name).IsUnique().HasDatabaseName("IX_Category_Name");
  }
}
