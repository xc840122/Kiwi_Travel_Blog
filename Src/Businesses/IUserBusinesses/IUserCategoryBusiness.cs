using System;
using Kiwi_Travel_Blog.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Businesses.IUserBusinesses;
/// <summary>
/// Business logic interface of category
/// </summary>
public interface IUserCategoryBusiness
{
  /// <summary>
  /// get all categories
  /// </summary>
  /// <returns></returns>
  public Task<List<Category>> GetAllCategories();
}
