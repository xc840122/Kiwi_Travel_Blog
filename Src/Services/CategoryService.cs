/// <summary>
/// category service
/// </summary>
/// <remarks>
/// service logic of category
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 07/10/2024
/// </author>
using System;
using Kiwi_Travel_Blog.Data.Entities;
using Kiwi_Travel_Blog.Interface;
using Kiwi_Travel_Blog.Interface.IServices;
using Kiwi_Travel_Blog.Src.Dtos;

namespace Kiwi_Travel_Blog.Src.Services;

public class CategoryService : ICategoryService
{
  private readonly ICategoryRepository _categoryRepository;

  public CategoryService(ICategoryRepository categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }
  public List<CategoryDto> GetAllCategories()
  {
    // get categories from repository layer
    List<Category> categories = _categoryRepository.GetAllCategories();
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
