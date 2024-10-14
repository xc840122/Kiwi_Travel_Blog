using System;
using Kiwi_Travel_Blog.Src.Dtos;

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
  public Task<List<CategoryDto>> GetAllCategories();
}
