using System;

namespace OXL_Assessment2.Src.Data.Entities;

public class Image
{
  public long Id { get; set; }
  public string? Url { get; set; }
  public Article? Article { get; set; }
}