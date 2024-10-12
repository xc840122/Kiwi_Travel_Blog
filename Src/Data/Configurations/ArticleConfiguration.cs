using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OXL_Assessment2.Src.Data.Entities;

namespace OXL_Assessment2.Src.Data.Configurations;
/// <summary>
/// Configuration of category table
/// </summary>
/// <remarks>
/// 
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 06/10/2024
/// </author>
public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
  public void Configure(EntityTypeBuilder<Article> builder)
  {
    builder.ToTable("T_Articles");
    builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
    builder.Property(e => e.Text).HasMaxLength(5000).IsRequired();
    // builder.HasMany<Image>(a => a.Images).WithOne(i => i.Article).IsRequired();
    // builder.HasMany<Comment>(a => a.Comments).WithOne(c => c.Article).IsRequired();
  }
}
