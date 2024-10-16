using System;

namespace Kiwi_Travel_Blog.Src.Data.Entities;
/// <summary>
/// Base Entity for common properties
/// </summary>
public class BaseEntity
{
  public DateTime CreateTime { get; set; }
  public DateTime UpdateTime { get; set; }
}
