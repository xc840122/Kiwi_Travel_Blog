using System;
using System.Text.Json.Serialization;

namespace Kiwi_Travel_Blog.Src.Data.Entities;
/// <summary>
/// comments from other user, for future expansion
/// </summary>
public class Comment : BaseEntity
{
  public long Id { get; set; }
  public required string Review { get; set; }
  public required string Reviewer { get; set; }
  public required long ArticleId { get; set; }
  public required Article Article { get; set; }
  public long LikeNum { get; set; }
  public string? Location { get; set; }
}
