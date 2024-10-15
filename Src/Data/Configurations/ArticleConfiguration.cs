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
    builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
    builder.Property(e => e.Text).HasMaxLength(5000).IsRequired();
    builder.Property(e => e.Author).IsRequired();
    builder.Property(e => e.CategoryId).IsRequired();
    builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
    builder.HasMany<Image>(a => a.Images).WithOne(i => i.Article).IsRequired();
    builder.HasMany<Comment>(a => a.Comments).WithOne(c => c.Article);
  }
}
