using System;
using Kiwi_Travel_Blog.Data;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Repositories.IAdminRepositories;

namespace Kiwi_Travel_Blog.Src.Repositories.AdminImpl;
/// <summary>
/// Insert a category into database
/// </summary>
public class AdminCategoryRepository : IAdminCategoryRepository
{
  private readonly AppDbContext _context;
  private readonly ILogger<AdminCategoryRepository> _logger;

  public AdminCategoryRepository(AppDbContext context, ILogger<AdminCategoryRepository> logger)
  {
    _context = context;
    _logger = logger;
  }
  /// <summary>
  /// Insert a category into database
  /// </summary>
  /// <param name="category"></param>
  /// <returns></returns>
  public async Task InsertCategory(Category category)
  {
    try
    {
      if (category == null)
      {
        throw new ArgumentNullException(nameof(category), "Category cannot be null");
      }

      await _context.Categories.AddAsync(category); // Add the category to the DbSet
      await _context.SaveChangesAsync(); // Save changes to the database

      _logger.LogInformation($"Category with {category.Id} inserted successfully");
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, $"An error occurred while inserting category for ID {category.Id}");
      throw; // Rethrow the exception after logging
    }
  }
}
