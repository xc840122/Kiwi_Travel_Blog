using System;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Dtos;

namespace Kiwi_Travel_Blog.Src.Businesses.IArticleBusiness;
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
  public Task<List<Article>> GetArticlesByCategoryId(long CategoryId);

  public Task AddArticle(ArticleDto articleDto);
}
