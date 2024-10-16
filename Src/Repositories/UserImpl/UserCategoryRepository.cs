using System;
using Kiwi_Travel_Blog.Data;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Repositories.IUserRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kiwi_Travel_Blog.Src.Repositories.UserImpl;
/// <summary>
/// repositories of category
/// </summary>
public class UserCategoryRepository : IUserCategoryRepository
{
  private readonly AppDbContext _context;
  private readonly ILogger<UserCategoryRepository> _logger;  // Inject ILogger for logging

  public UserCategoryRepository(AppDbContext context, ILogger<UserCategoryRepository> logger)
  {
    _context = context;
    _logger = logger;
  }
  /// <summary>
  /// Get all categories from database
  /// </summary>
  /// <returns></returns>
  public async Task<List<Category>> GetAllCategories()
  {
    try
    {
      _logger.LogInformation("Attempting to retrieve all categories from the database.");
      var categories = await _context.Categories.ToListAsync();

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
