using System;
using Kiwi_Travel_Blog.Src.Businesses.IArticleBusiness;
using Kiwi_Travel_Blog.Src.Dtos;
using Kiwi_Travel_Blog.Src.Repositories.IUserRepositories;

namespace Kiwi_Travel_Blog.Src.Services.IServices;
/// <summary>
/// user business logic of article
/// </summary>
public class UserArticleBusiness : IUserArticleBusiness
{
  private readonly IUserArticleRepository _articleRepository;
  private readonly ILogger<UserArticleBusiness> _logger;

  public UserArticleBusiness(IUserArticleRepository articleRepository, ILogger<UserArticleBusiness> logger)
  {
    _articleRepository = articleRepository;
    _logger = logger;
  }
  /// <summary>
  /// convert List<Article> to List<ArticleDto>
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