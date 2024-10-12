using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OXL_Assessment2.Data.Entities;
using OXL_Assessment2.Src.Data.Entities;

namespace OXL_Assessment2.Data.Configurations;
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
  }
}
