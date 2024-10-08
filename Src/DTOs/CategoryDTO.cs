/// <summary>
/// DTO of category
/// </summary>
/// <remarks>
/// used for internal transmission
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 08/10/2024
/// </author>
using System;

namespace OXL_Assessment2.DTOs;

public class CategoryDTO
{
  public long Id { get; set; }
  public string? Name { get; set; }
  public string? Description { get; set; }
}
