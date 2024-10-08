/// <summary>
/// Configuration of category table
/// </summary>
/// <remarks>
/// 
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 06/10/2024
/// </author>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OXL_Assessment2.Data.Entities;

namespace OXL_Assessment2.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.ToTable("T_Categories");
    builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
    builder.Property(e => e.Description).IsRequired();
  }
}