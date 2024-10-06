/// <summary>
/// base engity with createtime and updatetime
/// </summary>
/// <remarks>
/// for auto-udpate using, apply to all entities
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 06/10/2024
/// </author>
using System;

namespace OXL_Assessment2.Data.Entities;

public class BaseEntity
{
  public DateTime CreateTime { get; set; }
  public DateTime UpdateTime { get; set; }
}
