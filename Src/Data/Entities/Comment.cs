using System;
using OXL_Assessment2.Data.Entities;

namespace OXL_Assessment2.Src.Data.Entities;
/// <summary>
/// comments from other user, for future expansion
/// </summary>
public class Comment : BaseEntity
{
  public long Id { get; set; }
  public string? Review { get; set; }
  public string? Reviewer { get; set; }
  public Article? Article { get; set; }
  public string? LikeNum { get; set; }
  public string? Location { get; set; }
}
