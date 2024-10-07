/// <summary>
/// The Category class represents a category of contents in the system.
/// </summary>
/// <remarks>
/// The Category class is used to represent a category of contents in the system.
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 06/10/2024
/// </author>
using System;
using System.ComponentModel.DataAnnotations;

namespace OXL_Assessment2.Data.Entities;

public class Category : BaseEntity
{
  public long Id { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
}
