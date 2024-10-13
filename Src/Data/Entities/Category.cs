using System;
using System.ComponentModel.DataAnnotations;
using OXL_Assessment2.Src.Data.Entities;

namespace OXL_Assessment2.Data.Entities;
/// <summary>
/// The Category class represents a category of contents in the system.
/// </summary>
/// <remarks>
/// The Category class is used to represent a category of contents in the system.
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 06/10/2024
/// </author>
public class Category : BaseEntity
{
  public long Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
  public int Position { get; set; }
  public List<Article>? Articles { get; set; }
}
