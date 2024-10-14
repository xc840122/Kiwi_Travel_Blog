using System;
using Kiwi_Travel_Blog.Data.Entities;
using Kiwi_Travel_Blog.Interface;
using Kiwi_Travel_Blog.Interface.IServices;
using Kiwi_Travel_Blog.Src.Dtos;

namespace Kiwi_Travel_Blog.Src.Services;
/// <summary>
/// user business logic of category
/// </summary>
public class UserCategoryBusiness : IUserCategoryBusiness
{
  private readonly IUserCategoryRepository _categoryRepository;
  public UserCategoryBusiness(IUserCategoryRepository categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }
  /// <summary>
  /// user API to get all categories
  /// </summary>
  /// <returns></returns>
  public async Task<List<CategoryDto>> GetAllCategories()
  {
    // get categories from repository layer
    List<Category> categories = await _categoryRepository.GetAllCategories();
    // transfer to categoryDtos (mannual way)
    var categoryDTOs = categories.Select(e => new CategoryDto
    {
      Id = e.Id,
      Name = e.Name,
      Position = e.Position
    }).ToList();
    return categoryDTOs;
  }
}
