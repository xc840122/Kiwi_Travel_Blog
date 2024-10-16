using System;
using Kiwi_Travel_Blog.Src.Businesses.IUserBusinesses;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Dtos.UserDtos.UserCreatingDtos;
using Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserGettingDtos;
using Kiwi_Travel_Blog.Src.Repositories.IUserRepositories;

namespace Kiwi_Travel_Blog.Src.Businesses.UserImpl;
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
  public Task AddArticle(UserCreatingArticleDto articleDto)
  {
    try
    {
      if (articleDto == null)
      {
        _logger.LogWarning("Article cannot be null");
        throw new NullReferenceException("Article cannot be null");
      }

      // handle image relavant logic
      var images = articleDto.Images.Select(imageDto => new Image
      {
        Url = imageDto.Url,
        ArticleId = imageDto.ArticleId
      }).ToList();

      // Convert articleDto to article
      var article = new Article
      {
        Name = articleDto.Name,
        Text = articleDto.Text,
        Author = articleDto.Author,
        Location = articleDto.Location,
        CategoryId = articleDto.CategoryId,
        Images = images
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
  public async Task<List<UserGettingArticleDto>> GetArticlesByCategoryId(long CategoryId)
  {
    try
    {
      // Get articles from repository
      var aritcles = await _articleRepository.GetArticlesByCategoryId(CategoryId);
      if (aritcles == null)
      {
        _logger.LogWarning("Articles result cannot be null");
        throw new NullReferenceException("Articles result cannot be null");
      }

      // Convert Article to UserGettingArticleDto
      var userGettingArticleDtos = aritcles.Select(article => new UserGettingArticleDto
      {
        Id = article.Id,
        Name = article.Name,
        Author = article.Author,
        LikeNums = article.LikeNums,
        CoverImage = article.Images
        .Select(img => new UserGettingImageDto { Id = img.Id, Url = img.Url })
        .ToList()[0] // Convet to cover Image (UserGettingImageDto)
      }).ToList();
      return userGettingArticleDtos;

    }
    catch (Exception ex)
    {
      // Log the exception
      _logger.LogError(ex, "Error retrieving articles for category ID {CategoryId}", CategoryId);
      throw;
    }
  }
}
