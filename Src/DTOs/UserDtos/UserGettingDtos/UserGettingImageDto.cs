using System;

namespace Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserGettingDtos;
/// <summary>
/// Response model, avoid cycling reference coz Efcore navigation
/// </summary>
public class UserGettingImageDto
{
  public long Id { get; set; }
  public required string Url { get; set; }
}
