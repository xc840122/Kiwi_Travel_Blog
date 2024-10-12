using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using OXL_Assessment2.Data.Entities;

namespace OXL_Assessment2.Src.Data.Entities;
/// <summary>
/// Article entity
/// </summary>
public class Article : BaseEntity
{
  public long Id { get; set; }
  public string? Name { get; set; }
  public string? Text { get; set; }
  public NZTUser? Author { get; set; }
  public long LikeNums { get; set; } //for future expansion
  public long FavoriteNums { get; set; } //for future expansion
  public string? Location { get; set; }  //for future expansion
  public Category? Category { get; set; }
  public List<Image>? Images { get; set; }
  public List<Comment>? Comments { get; set; }
}