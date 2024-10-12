using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OXL_Assessment2.Src.Data.Entities;

namespace OXL_Assessment2.Src.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
  public void Configure(EntityTypeBuilder<Comment> builder)
  {
    builder.ToTable("T_Comments");
  }
}
