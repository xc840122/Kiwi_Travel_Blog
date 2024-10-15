using System;
using Kiwi_Travel_Blog.Data.Entities;
using Kiwi_Travel_Blog.Src.Businesses.IAdminBusinesses;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Dtos;
using Kiwi_Travel_Blog.Src.Repositories.IAdminRepositories;

namespace Kiwi_Travel_Blog.Src.Businesses.AdminImpl;
/// <summary>
/// Admin business logic
/// </summary>
public class AdminCategoryBusiness : IAdminCategoryBusiness
{
  private readonly IAdminCategoryRepository _categoryRepository;
  private readonly ILogger<AdminCategoryBusiness> _logger;
  public AdminCategoryBusiness(IAdminCategoryRepository categoryRepository, ILogger<AdminCategoryBusiness> logger)
  {
    _categoryRepository = categoryRepository;
    _logger = logger;
  }
  /// <summary>
  /// Add category
  /// </summary>
  /// <param name="categoryDto"></param>
  /// <returns></returns>
  public async Task AddCategory(CategoryDto categoryDto)
  {
    try
    {
      if (categoryDto == null)
      {
        throw new ArgumentNullException(nameof(categoryDto), "Category cannot be null");
      }

      // TODO: logic to check duplicated category name
      // TODO: logic to check upper category

      var category = new Category
      {
        Name = categoryDto.Name,
        Description = categoryDto.Description,
        Position = categoryDto.Position,
        UpperCategoryId = categoryDto.UpperCategoryId,
        Articles = new List<Article>()  // empty list, avoid null
      };

      _logger.LogInformation($"Add category for id {category.Id}");
      await _categoryRepository.InsertCategory(category); //add category
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, $"An error occurred while adding category for name {categoryDto.Name}");
    }
  }
}
