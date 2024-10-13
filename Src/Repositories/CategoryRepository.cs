/// <summary>
/// category repository
/// </summary>
/// <remarks>
/// operate category data from database
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 07/10/2024
/// </author>
using System;
using OXL_Assessment2.Data;
using OXL_Assessment2.Data.Entities;
using OXL_Assessment2.Interface.IServices;

namespace OXL_Assessment2.Src.Repositories;

public class CategoryRepository : ICategoryRepository
{
  private readonly AppDbContext _context;
  private readonly ILogger<CategoryRepository> _logger;  // Inject ILogger for logging

  public CategoryRepository(AppDbContext context, ILogger<CategoryRepository> logger)
  {
    _context = context;
    _logger = logger;
  }
  public List<Category> GetAllCategories()
  {
    try
    {
      _logger.LogInformation("Attempting to retrieve all categories from the database.");
      var categories = _context.Categories.ToList();

      _logger.LogInformation("Successfully retrieved {Count} categories.", categories.Count);
      return categories;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "An error occurred while retrieving categories from the database.");
      throw; // Rethrow the exception to propagate it up the call stack
    }
  }
}
