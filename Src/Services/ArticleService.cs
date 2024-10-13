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

  // get username


  /// <summary>
  /// service method: get articles by category id
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns>List<ArticleDto></returns>
  public async Task<List<ArticleDto>> GetArticlesByCategoryId(long CategoryId)
  {
    // articles from repository
    var aritcles = await _articleRepository.GetArticlesByCategoryId(CategoryId);
    // get user info

    // map to ArticleDto
    var articleDtos = aritcles.Select(a => new
    {
      Id = a.Id,
      Name = a.Name,
      CoverImage = a.CoverImage,
      LikeNums = a.LikeNums
    });
    throw new NotImplementedException();
  }
}
