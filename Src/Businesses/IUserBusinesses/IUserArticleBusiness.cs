using System;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Dtos;
using Kiwi_Travel_Blog.Src.Dtos.UserDtos.UserCreatingDtos;
using Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserGettingDtos;

namespace Kiwi_Travel_Blog.Src.Businesses.IUserBusinesses;
/// <summary>
/// interface of article business
/// </summary>
public interface IUserArticleBusiness
{
  /// <summary>
  /// get articles by category id business
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns></returns>
  public Task<List<UserGettingArticleDto>> GetArticlesByCategoryId(long CategoryId);

  public Task AddArticle(UserCreatingArticleDto articleDto);
}
