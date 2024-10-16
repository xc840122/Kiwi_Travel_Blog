using System;

namespace Kiwi_Travel_Blog.Src.DTOs.AdminDtos.AdminCreationDtos;
/// <summary>
/// model for category creation use
/// </summary>
public class AdminCategoryCreationDto
{
  public required string Name { get; set; }
  public required string Description { get; set; }
  public long UpperCategoryId { get; set; }
  public int Position { get; set; } = 0;
}
