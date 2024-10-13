using System;
using OXL_Assessment2.Src.Dtos;

namespace OXL_Assessment2.Src.Services.IServices;
/// <summary>
/// interface of article service
/// </summary>
public interface IArticleService
{
  /// <summary>
  /// get articles by category id service
  /// </summary>
  /// <param name="CategoryId"></param>
  /// <returns></returns>
  public Task<List<ArticleDto>> GetArticlesByCategoryId(long CategoryId);
}
