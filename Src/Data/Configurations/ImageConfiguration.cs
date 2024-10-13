using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OXL_Assessment2.Src.Data.Entities;

namespace OXL_Assessment2.Src.Data.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
  public void Configure(EntityTypeBuilder<Image> builder)
  {
    builder.ToTable("T_Images");
  }
}
