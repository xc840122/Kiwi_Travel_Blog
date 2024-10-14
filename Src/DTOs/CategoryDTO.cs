using System;

namespace Kiwi_Travel_Blog.Src.Dtos;

public class CategoryDto
{
  public long Id { get; set; }
  public required string Name { get; set; }
  public int Position { get; set; }
}
