using System;

namespace Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserCreatingDtos;
/// <summary>
/// Model for creating comment
/// </summary>
public class UserCreatingCommentDto
{
  public required string Review { get; set; }
  public required string Reviewer { get; set; }
  public required long ArticleId { get; set; }
  public long LikeNum { get; set; }
  public string? Location { get; set; }
}
