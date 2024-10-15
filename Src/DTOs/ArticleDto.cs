using System;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Dtos;

public class ArticleDto
{
  public required string Name { get; set; }
  public required string Author { get; set; }
  public required string Text { get; set; }
  public required long CategoryId { get; set; } //for future expansion
  public required List<Image> Images { get; set; }
}
