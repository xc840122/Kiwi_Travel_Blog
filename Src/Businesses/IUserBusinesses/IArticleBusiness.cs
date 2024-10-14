using System;
using Kiwi_Travel_Blog.Src.Dtos;

namespace Kiwi_Travel_Blog.Src.Businesses.IArticleBusiness;
/// <summary>
/// interface of article business
/// </summary>
public interface IArticleBusiness
{
  /// <summary>
  /// get articles by category id business
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns></returns>
  public Task<List<ArticleDto>> GetArticlesByCategoryId(long CategoryId);
}
