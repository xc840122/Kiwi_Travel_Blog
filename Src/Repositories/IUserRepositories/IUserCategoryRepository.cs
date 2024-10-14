using System;
using Kiwi_Travel_Blog.Data.Entities;

namespace Kiwi_Travel_Blog.Interface.IServices;
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
