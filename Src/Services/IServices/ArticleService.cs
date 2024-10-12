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
  /// service method: get articles by category id
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns>List<ArticleDto></returns>
  public Task<List<ArticleDto>> GetArticlesByCategoryId(long CategoryId)
  {
    throw new NotImplementedException();
  }
}
