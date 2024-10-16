using System;
using System.Text.Json.Serialization;

namespace Kiwi_Travel_Blog.Src.Data.Entities;
/// <summary>
/// Article entity
/// </summary>
public class Article : BaseEntity
{
  public long Id { get; set; }
  public required string Name { get; set; }
  public required string Text { get; set; }
  public required string Author { get; set; }
  public long LikeNums { get; set; } //for future expansion
  public long FavoriteNums { get; set; } //for future expansion
  public string? Location { get; set; }  //for future expansion
  public required long CategoryId { get; set; }
  public Category? Category { get; set; }
  [JsonIgnore]
  public required List<Image> Images { get; set; }
  [JsonIgnore]
  public List<Comment>? Comments { get; set; }
}
