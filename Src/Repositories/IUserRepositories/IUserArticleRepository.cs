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
  public Task<IEnumerable<Article>> GetArticlesByCategoryId(long CategoryId);

  public Task InsertArticle(Article article);
}
