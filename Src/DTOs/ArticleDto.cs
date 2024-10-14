using System;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Dtos;

public class ArticleDto
{
  public long Id { get; set; }
  public required string Name { get; set; }
  public required string CoverImage { get; set; }
  public required string Author { get; set; }
  public long LikeNums { get; set; }
}
