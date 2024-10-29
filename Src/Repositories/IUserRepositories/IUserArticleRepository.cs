using System;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Repositories.IUserRepositories;
/// <summary>
/// Repository interface of article
/// </summary>
public interface IUserArticleRepository
{
  /// <summary>
  /// medhod to get articles by category id
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns></returns>
  public Task<List<Article>> GetArticlesByCategoryId(long categoryId);

  /// <summary>
  /// Insert new article into db
  /// </summary>
  /// <param name="article"></param>
  /// <returns></returns>
  public Task InsertArticle(Article article);

  /// <summary>
  /// Get the article with request id from db
  /// </summary>
  /// <param name="articleId"></param>
  /// <returns></returns>
  public Task<Article> GetArticle(long articleId);
}
