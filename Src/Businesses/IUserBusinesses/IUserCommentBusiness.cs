using System;
using Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserCreatingDtos;

namespace Kiwi_Travel_Blog.Src.Businesses.IUserBusinesses;
/// <summary>
/// Interface of comment business
/// </summary>
public interface IUserCommentBusiness
{
  /// <summary>
  /// User add comment
  /// </summary>
  /// <param name="userCreatingCommentDto"></param>
  /// <returns></returns>
  public Task<bool> AddComment(UserCreatingCommentDto userCreatingCommentDto);
}
