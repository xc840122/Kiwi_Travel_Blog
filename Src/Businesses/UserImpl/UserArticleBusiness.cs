using System;
using Kiwi_Travel_Blog.Src.Businesses.IArticleBusiness;
using Kiwi_Travel_Blog.Src.Data.Entities;
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
  /// Add an article
  /// </summary>
  /// <param name="articleDto"></param>
  /// <returns></returns>
  public Task AddArticle(ArticleDto articleDto)
  {
    try
    {
      if (articleDto == null)
      {
        _logger.LogWarning("Article cannot be null");
        throw new NullReferenceException("Article cannot be null");
      }

      // Convert articleDto to article
      var article = new Article
      {
        Name = articleDto.Name,
        Text = articleDto.Text,
        Author = articleDto.Author,
        LikeNums = 0,
        FavoriteNums = 0,
        Location = "New Zealand",
        CategoryId = articleDto.CategoryId,
        Images = articleDto.Images
      };
      // add article
      _logger.LogInformation($"Add an artile for Name {article.Name}");
      _articleRepository.InsertArticle(article);

      return Task.CompletedTask;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, $"An Error occurers while adding an article for name {articleDto.Name}");
      throw;
    }
  }

  /// <summary>
  /// convert List<Article> to List<ArticleDto>
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns>List<ArticleDto></returns>
  public async Task<List<Article>> GetArticlesByCategoryId(long CategoryId)
  {
    try
    {
      // articles from repository
      var aritcles = await _articleRepository.GetArticlesByCategoryId(CategoryId);
      if (aritcles == null)
      {
        _logger.LogWarning("Articles result cannot be null");
        throw new NullReferenceException("Articles result cannot be null");
      }
      else
      {
        return aritcles;
      }
    }
    catch (Exception ex)
    {
      // Log the exception
      _logger.LogError(ex, "Error retrieving articles for category ID {CategoryId}", CategoryId);
      throw;
    }
  }
}
