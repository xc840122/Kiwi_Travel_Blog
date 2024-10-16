using System;
using Kiwi_Travel_Blog.Src.Businesses.IUserBusinesses;
using Kiwi_Travel_Blog.Src.Repositories.IUserRepositories;
using Kiwi_Travel_Blog.Src.Dtos.UserDtos.UserGettingDtos;

namespace Kiwi_Travel_Blog.Src.Businesses.UserImpl;
/// <summary>
/// user business logic of category
/// </summary>
public class UserCategoryBusiness : IUserCategoryBusiness
{
  private readonly IUserCategoryRepository _categoryRepository;
  private readonly ILogger<UserCategoryBusiness> _logger;
  public UserCategoryBusiness(IUserCategoryRepository categoryRepository, ILogger<UserCategoryBusiness> logger)
  {
    _categoryRepository = categoryRepository;
    _logger = logger;
  }
  /// <summary>
  /// user API to get all categories
  /// </summary>
  /// <returns></returns>
  public async Task<List<UserGettingCategoryDto>> GetAllCategories()
  {
    // Get categories from repository layer
    var categories = await _categoryRepository.GetAllCategories();
    if (categories == null)
    {
      _logger.LogWarning("Categories cannot be null");
      throw new NullReferenceException("Categories cannot be null");
    }

    // Convert List<Category> to List<UserGettingCategoryDto>
    var userGettingCategoryDtos = categories.Select(categoryItem => new UserGettingCategoryDto
    {
      Id = categoryItem.Id,
      Name = categoryItem.Name,
      UpperCategoryId = categoryItem.UpperCategoryId,
      Position = categoryItem.Position
    }).ToList();

    return userGettingCategoryDtos;
  }
}
