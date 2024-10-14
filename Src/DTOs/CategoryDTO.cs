using System;

namespace Kiwi_Travel_Blog.Src.Dtos;

public class CategoryDto
{
  public required string Name { get; set; }
  public required string Description { get; set; }
  public long UpperCategoryId { get; set; }
  public int Position { get; set; } = 0;
}
