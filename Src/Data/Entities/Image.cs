using System;

namespace Kiwi_Travel_Blog.Src.Data.Entities;

public class Image
{
  public long Id { get; set; }
  public required string Url { get; set; }
  public Article? Article { get; set; }
}
