using System;
using Kiwi_Travel_Blog.Src.Dtos;

namespace Kiwi_Travel_Blog.Interface;
/// <summary>
/// Business logic interface of category
/// </summary>
public interface ICategoryBusiness
{
  /// <summary>
  /// get all categories
  /// </summary>
  /// <returns></returns>
  public List<CategoryDto> GetAllCategories();
}
