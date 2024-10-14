using System;

namespace Kiwi_Travel_Blog.Src.Repositories.IAdminRepositories;
/// <summary>
/// Admin interface of article repository
/// </summary>
public interface IAdminArticleRepository
{
  /// <summary>
  /// Insert category into database
  /// </summary>
  /// <returns></returns>
  public Task InsertCategory();
}
