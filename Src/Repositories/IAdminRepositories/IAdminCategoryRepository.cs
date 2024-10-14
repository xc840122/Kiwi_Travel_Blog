using System;
using Kiwi_Travel_Blog.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Repositories.IAdminRepositories;
/// <summary>
/// Admin interface of category repository
/// </summary>
public interface IAdminCategoryRepository
{
  /// <summary>
  /// Insert category into database
  /// </summary>
  /// <returns></returns>
  public Task InsertCategory(Category category);
}
