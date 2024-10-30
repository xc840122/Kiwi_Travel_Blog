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
  /// convert List<Article> to List<ArticleDto>
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns>List<ArticleDto></returns>
  public async Task<List<UserGettingArticleDto>> GetArticlesByCategoryId(long categoryId)
  {
    try
    {
      // Get articles from repository
      var articles = await _articleRepository.GetArticlesByCategoryId(categoryId);
      if (articles == null)
      {
        _logger.LogWarning("Articles result cannot be null");
        throw new NullReferenceException("Articles result cannot be null");
      }

      // Convert Article to UserGettingArticleDto
      var userGettingArticleDtos = articles.Select(article => new UserGettingArticleDto
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
      _logger.LogError(ex, "Error retrieving articles for category ID {categoryId}", categoryId);
      throw;
    }
  }
  /// <summary>
  /// Add an article
  /// </summary>
  /// <param name="articleDto"></param>
  /// <returns></returns>
  public async Task AddArticle(UserCreatingArticleDto articleDto)
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
      await _articleRepository.InsertArticle(article);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, $"An Error occurers while adding an article for name {articleDto.Name}");
      throw;
    }
  }

  /// <summary>
  /// Get an Article, convert data from db to response format
  /// </summary>
  /// <param name="articleId"></param>
  /// <returns></returns>
  public async Task<UserGettingArticleDetailDto> GetArticle(long articleId)
  {
    try
    {
      // Get article from repository
      var article = await _articleRepository.GetArticle(articleId);
      if (article == null)
      {
        _logger.LogWarning("Article result cannot be null");
        throw new NullReferenceException("Article result cannot be null");
      }

      //Convert images to dto (In future, can add default image)
      if (article.Images == null)
      {
        _logger.LogWarning("Images result cannot be null");
        throw new NullReferenceException("Images result cannot be null");
      }

      var imageDtos = article.Images.Select(img => new UserGettingImageDto
      {
        Id = img.Id,
        Url = img.Url
      }).ToList();

      // Convert comment to dto, comment can be null, means no comments
      var commentDtos = new List<UserGettingCommentDto>();
      if (article.Comments != null)
      {
        commentDtos = article.Comments.Select(c => new UserGettingCommentDto
        {
          Id = c.Id,
          Review = c.Review,
          Reviewer = c.Reviewer,
          LikeNum = c.LikeNum,
          Location = c.Location, //TODO: future expansion, use real Geo API
          CreateTime = c.CreateTime,
          UpdateTime = c.UpdateTime
        }).ToList();
      }
      // Convert Article to UserGettingArticleDto
      var UserGettingArticleDetailDto = new UserGettingArticleDetailDto
      {
        Id = article.Id,
        Name = article.Name,
        Text = article.Text,
        Author = article.Author,
        LikeNums = article.LikeNums,
        FavoriteNums = article.FavoriteNums,
        Location = article.Location,
        Images = imageDtos,
        Comments = commentDtos,
        CreateTime = article.CreateTime,
        UpdateTime = article.UpdateTime
      };
      return UserGettingArticleDetailDto;
    }
    catch (Exception ex)
    {
      // Log the exception
      _logger.LogError(ex, $"Error retrieving article for ID ${articleId}");
      throw;
    }
  }
}
