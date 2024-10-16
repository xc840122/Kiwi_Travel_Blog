using System;
using System.Text.Json.Serialization;

namespace Kiwi_Travel_Blog.Src.Data.Entities;

public class Image : BaseEntity
{
  public long Id { get; set; }
  public required string Url { get; set; }
  public required long ArticleId { get; set; }
  public Article? Article { get; set; } //exclude from serialization (API response)
}
