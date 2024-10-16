using System;
using System.Text.Json.Serialization;

namespace Kiwi_Travel_Blog.Src.Data.Entities;
/// <summary>
/// Category entity
/// </summary>
public class Category : BaseEntity
{
  public long Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
  public long UpperCategoryId { get; set; }
  public int Position { get; set; } = 0;
  [JsonIgnore]
  public List<Article>? Articles { get; set; } //exclude from serialization to prevent cycling reference
}
