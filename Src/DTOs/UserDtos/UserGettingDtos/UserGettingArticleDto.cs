using System;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserGettingDtos;

/// <summary>
/// Response model, avoid cycling reference coz Efcore navigation
/// </summary>
public class UserGettingArticleDto : BaseEntity
{
  public required long Id { get; set; }
  public required string Name { get; set; }
  public required string Author { get; set; }
  public required long LikeNums { get; set; } //for future expansion
  // public required UserGettingImageDto CoverImage { get; set; }
}
