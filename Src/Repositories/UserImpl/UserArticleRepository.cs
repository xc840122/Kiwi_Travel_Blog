using System;
using Microsoft.EntityFrameworkCore;
using Kiwi_Travel_Blog.Data;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Repositories.IUserRepositories;

namespace Kiwi_Travel_Blog.Src.Repositories;
/// <summary>
/// Repository of Article
/// </summary>
public class UserArticleRepository : IUserArticleRepository
{
  private readonly AppDbContext _context;
  private readonly ILogger<UserArticleRepository> _logger;

  public UserArticleRepository(AppDbContext context, ILogger<UserArticleRepository> logger)
  {
    _context = context;
    _logger = logger;
  }
  /// <summary>
  /// async medhod to fetch article data from db
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns>List<Article></returns>
  public async Task<IEnumerable<Article>> GetArticlesByCategoryId(long CategoryId)
  {
    try
    {
      // try to fetch category
      var category = await _context.Categories
          .Where(c => c.Id == CategoryId)
          .SingleOrDefaultAsync();

      // Verify if category exists
      if (category == null)
      {
        _logger.LogWarning("Category with ID {CategoryId} not found.", CategoryId);
        return new List<Article>(); // Return empty list if category not found
      }

      // category exists, fetch articles
      _logger.LogInformation("Fetching articles for category ID {CategoryId}", category.Id);
      var articles = await _context.Articles
          .Where(a => a.CategoryId == CategoryId)
          .ToListAsync<Article>();
      return articles;
    }
    catch (InvalidOperationException ex)
    {
      // Handle case when more than one category is returned unexpectedly
      _logger.LogError(ex, "Multiple categories found for ID {CategoryId}.", CategoryId);
      throw;
    }
    catch (Exception ex)
    {
      // Handle any other exceptions
      _logger.LogError(ex, "An error occurred while fetching articles for category ID {CategoryId}.", CategoryId);
      throw; // Rethrow the exception after logging
    }
  }
  /// <summary>
  /// Insert article into database
  /// </summary>
  /// <param name="article"></param>
  /// <returns></returns>
  /// <exception cref="NotImplementedException"></exception>
  public async Task InsertArticle(Article article)
  {
    try
    {
      // verify if article exists
      if (article == null)
      {
        _logger.LogWarning($"Article cannot be null");
        throw new ArgumentNullException("Article cannot be null");
      }

      // insert article into database
      await _context.Articles.AddAsync(article);
      await _context.SaveChangesAsync();

      _logger.LogInformation($"Category with {article.Id} inserted successfully");
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, $"An error occurred while inserting category for ID {article.Id}");
      throw;
    }
  }
}
