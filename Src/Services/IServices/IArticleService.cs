using System;
using Kiwi_Travel_Blog.Src.Dtos;

namespace Kiwi_Travel_Blog.Src.Services.IServices;
/// <summary>
/// interface of article service
/// </summary>
public interface IArticleService
{
  /// <summary>
  /// get articles by category id service
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns></returns>
  public Task<List<ArticleDto>> GetArticlesByCategoryId(long CategoryId);
}
