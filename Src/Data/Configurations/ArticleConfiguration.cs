using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Data.Configurations;
/// <summary>
/// Database configuration of Article
/// </summary>
public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
  public void Configure(EntityTypeBuilder<Article> builder)
  {
    builder.ToTable("T_Articles");
    builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
    builder.Property(e => e.Text).HasMaxLength(5000).IsRequired();
    builder.Property(e => e.Author).IsRequired();
    builder.Property(e => e.CategoryId).IsRequired();

    // Add index, unique
    builder.HasIndex(e => e.Name).IsUnique().HasDatabaseName("IX_Article_Name");
  }
}
