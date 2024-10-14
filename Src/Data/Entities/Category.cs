using System;
using System.ComponentModel.DataAnnotations;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Data.Entities;
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
