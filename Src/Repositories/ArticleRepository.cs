using System;
using OXL_Assessment2.Data;
using OXL_Assessment2.Src.Data.Entities;
using OXL_Assessment2.Src.Repositories.IRepositories;

namespace OXL_Assessment2.Src.Repositories;
/// <summary>
/// Repository of Article
/// </summary>
public class ArticleRepository : IArticleRepository
{
  private readonly AppDbContext _context;
  private readonly Logger<ArticleRepository> _logger;

  public ArticleRepository(AppDbContext context, Logger<ArticleRepository> logger)
  {
    _context = context;
    _logger = logger;
  }
  public List<Article> GetArticlesByCategory(long CategoryId)
  {
    var category = _context.Categories.Where(c => c.Id == CategoryId).Single();
    // Verify if category exists
    if (category != null)
    {

    }
    var articles = _context.Articles.Where(a => a.Category != null && a.Category.Id == CategoryId).ToList();
    return articles;
  }
}
