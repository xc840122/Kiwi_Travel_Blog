using System;
using Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserCreatingDtos;

namespace Kiwi_Travel_Blog.Src.Dtos.UserDtos.UserCreatingDtos;
/// <summary>
/// Dto for post article
/// </summary>
public class UserCreatingArticleDto
{
  public required string Name { get; set; }
  public required string Author { get; set; }
  public required string Text { get; set; }
  public string? Location { get; set; }  //for future expansion
  public required long CategoryId { get; set; }
  public required List<UserCreatingImageDto> Images { get; set; }
}
