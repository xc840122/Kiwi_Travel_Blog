using System;

namespace Kiwi_Travel_Blog.Data.Entities;
/// <summary>
/// base engity with createtime and updatetime
/// </summary>
/// <remarks>
/// for auto-udpate using, apply to all entities
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 06/10/2024
/// </author>
public class BaseEntity
{
  public DateTime CreateTime { get; set; }
  public DateTime UpdateTime { get; set; }
}
