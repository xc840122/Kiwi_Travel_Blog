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
using OXL_Assessment2.Data.Entities;
using OXL_Assessment2.DTOs;
using OXL_Assessment2.Interface;
using OXL_Assessment2.Interface.IServices;

namespace OXL_Assessment2.Src.Services;

public class CategoryService : ICategoryService
{
  private readonly ICategoryRepository _categoryRepository;

  public CategoryService(ICategoryRepository categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }
  public List<CategoryDTO> GetAllCategories()
  {
    // get categories from repository layer
    List<Category> categories = _categoryRepository.GetAllCategories();
    // transfer to categoryDtos (mannual way)
    var categoryDTOs = categories.Select(e => new CategoryDTO
    {
      Id = (long)e.Id,
      Name = e.Name,
      Description = e.Description
    }).ToList();
    return categoryDTOs;
  }
}
