using System;

namespace Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserGettingDtos;

public class UserGettingArticleDetailDto
{
  public long Id { get; set; }
  public required string Name { get; set; }
  public required string Text { get; set; }
  public required string Author { get; set; }
  public long LikeNums { get; set; } //for future expansion
  public long FavoriteNums { get; set; } //for future expansion
  public required string? Location { get; set; }  //for future expansion
  public required List<UserGettingImageDto> Images { get; set; }
  public List<UserGettingCommentDto>? Comments { get; set; }
  public DateTime CreateTime { get; set; }
  public DateTime UpdateTime { get; set; }
}
