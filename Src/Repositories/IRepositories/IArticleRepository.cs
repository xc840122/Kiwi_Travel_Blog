using System;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Repositories.IRepositories;
/// <summary>
/// Repository interface of article
/// </summary>
public interface IArticleRepository
{
  /// <summary>
  /// medhod to get articles by category id
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns></returns>
  public Task<List<Article>> GetArticlesByCategoryId(long CategoryId);
}
