using System;
using OXL_Assessment2.Src.Data.Entities;

namespace OXL_Assessment2.Src.Repositories.IRepositories;
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
  public List<Article> GetArticlesByCategory(long CategoryId);
}
