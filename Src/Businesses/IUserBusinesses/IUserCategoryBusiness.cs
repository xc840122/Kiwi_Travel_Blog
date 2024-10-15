using System;
using Kiwi_Travel_Blog.Data.Entities;

namespace Kiwi_Travel_Blog.Interface;
/// <summary>
/// Business logic interface of category
/// </summary>
public interface IUserCategoryBusiness
{
  /// <summary>
  /// get all categories
  /// </summary>
  /// <returns></returns>
  public Task<IEnumerable<Category>> GetAllCategories();
}
