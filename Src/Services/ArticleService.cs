using System;
using OXL_Assessment2.Src.Dtos;
using OXL_Assessment2.Src.Repositories.IRepositories;

namespace OXL_Assessment2.Src.Services.IServices;
/// <summary>
/// service of article
/// </summary>
public class ArticleService : IArticleService
{
  private readonly IArticleRepository _articleRepository;
  private readonly ILogger<ArticleService> _logger;

  public ArticleService(IArticleRepository articleRepository, ILogger<ArticleService> logger)
  {
    _articleRepository = articleRepository;
    _logger = logger;
  }
  /// <summary>
  /// service method,convert List<Article> to List<ArticleDto>
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns>List<ArticleDto></returns>
  public async Task<List<ArticleDto>> GetArticlesByCategoryId(long CategoryId)
  {
    try
    {
      // articles from repository
      var aritcles = await _articleRepository.GetArticlesByCategoryId(CategoryId);

      // map to ArticleDto
      var articleDtos = aritcles.Select(a => new ArticleDto
      {
        Id = a.Id,
        Name = a.Name,
        CoverImage = a.CoverImage,
        Author = a.Author,
        LikeNums = a.LikeNums
      }).ToList();

      return articleDtos;
    }
    catch (Exception ex)
    {
      // Log the exception
      _logger.LogError(ex, "Error retrieving articles for category ID {CategoryId}", CategoryId);
      throw;
    }
  }
}
