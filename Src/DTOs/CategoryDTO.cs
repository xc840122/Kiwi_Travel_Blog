using System;

namespace Kiwi_Travel_Blog.Src.Dtos;

public class CategoryDto
{
  public long Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
  public int Position { get; set; } = 0;
  public string UpperCategoryId { get; set; } = "00";
}
