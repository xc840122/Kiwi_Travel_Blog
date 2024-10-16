using System;

namespace Kiwi_Travel_Blog.Src.Dtos.UserDtos.UserGettingDtos;
/// <summary>
/// Response model, avoid cycling reference coz Efcore navigation
/// </summary>
public class UserGettingCategoryDto
{
  public long Id { get; set; }
  public required string Name { get; set; }
  public long UpperCategoryId { get; set; }
  public int Position { get; set; } = 0;
}
