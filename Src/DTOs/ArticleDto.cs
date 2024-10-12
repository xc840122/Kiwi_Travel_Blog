using System;
using OXL_Assessment2.Src.Data.Entities;

namespace OXL_Assessment2.Src.Dtos;

public class ArticleDto
{
  public long Id { get; set; }
  public string? Name { get; set; }
  public string? CoverImage { get; set; }
  public string? Author { get; set; }
  public long LikeNums { get; set; }
}
