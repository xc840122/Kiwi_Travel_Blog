using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Data.Configurations;
/// <summary>
/// atabase configuration of Image
/// </summary>
public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
  public void Configure(EntityTypeBuilder<Image> builder)
  {
    builder.ToTable("T_Images");
  }
}
