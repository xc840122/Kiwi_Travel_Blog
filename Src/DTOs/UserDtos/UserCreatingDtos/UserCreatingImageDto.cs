using System;
namespace Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserCreatingDtos;
/// <summary>
/// Model for image uploading to specific article
/// </summary>
public class UserCreatingImageDto
{
  public required string Url { get; set; }
}
