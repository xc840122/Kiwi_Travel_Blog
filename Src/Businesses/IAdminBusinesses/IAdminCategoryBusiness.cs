using System;
using Kiwi_Travel_Blog.Src.DTOs.AdminDtos.AdminCreationDtos;

namespace Kiwi_Travel_Blog.Src.Businesses.IAdminBusinesses;
/// <summary>
/// Admin interfaces of category business
/// </summary>
public interface IAdminCategoryBusiness
{
  /// <summary>
  /// Add category
  /// </summary>
  /// <param name="categoryDto"></param>
  /// <returns></returns>
  public Task AddCategory(AdminCategoryCreationDto categoryDto);
}
