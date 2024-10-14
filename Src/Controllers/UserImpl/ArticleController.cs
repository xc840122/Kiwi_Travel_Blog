using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Dtos;
using Kiwi_Travel_Blog.Src.Businesses.IArticleBusiness;

namespace Kiwi_Travel_Blog.Src.Controllers;

/// <summary>
/// article controllers of user
/// </summary>
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ArticleController : AbstractBaseController
{
    private readonly IArticleBusiness _articleBusiness;
    private readonly ILogger<ArticleController> _logger;

    public ArticleController(IArticleBusiness articleBusiness, ILogger<ArticleController> logger)
    {
        _articleBusiness = articleBusiness;
        _logger = logger;
    }
    /// <summary>
    /// api to get articles by categoryId
    /// </summary>
    /// <param name="CategoryId"></param>
    /// <returns>list of article dto</returns>
    [ModelStateVerification]
    [HttpGet("{CategoryId}")]
    public async Task<IActionResult> GetArticlesByCategoryId(long CategoryId)
    {
        try
        {
            var articleDtos = await _articleBusiness.GetArticlesByCategoryId(CategoryId);
            if (articleDtos.Count > 0)
            {
                return Ok(CreateResponse<List<ArticleDto>>(ServiceCode.GettingArticleSuccessful,
                MessageConstants.GettingArticlesSuccessful, articleDtos));
            }
            else
            {
                _logger.LogWarning("Articles are not found");
                return NotFound(CreateResponse(ServiceCode.NoArticlesFound,
                MessageConstants.NotFoundData));
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
