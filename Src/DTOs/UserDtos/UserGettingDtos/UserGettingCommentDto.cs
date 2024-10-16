using System;

namespace Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserGettingDtos;
/// <summary>
/// Response model, avoid cycling reference coz Efcore navigation
/// </summary>
public class UserGettingCommentDto
{
  public long Id { get; set; }
  public required string Review { get; set; }
  public required string Reviewer { get; set; }
  public long LikeNum { get; set; }
  public string? Location { get; set; }
}
