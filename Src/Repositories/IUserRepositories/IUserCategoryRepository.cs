using System;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Repositories.IUserRepositories;
/// <summary>
/// User interface of category repository
/// </summary>
public interface IUserCategoryRepository
{
  /// <summary>
  /// Get all categories
  /// </summary>
  /// <returns></returns>
  public Task<List<Category>> GetAllCategories();
}
