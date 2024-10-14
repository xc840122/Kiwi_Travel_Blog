using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Businesses.IArticleBusiness;
using Kiwi_Travel_Blog.Src.Data.Entities;

namespace Kiwi_Travel_Blog.Src.Controllers;

/// <summary>
/// article controllers of user
/// </summary>
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserArticleController : AbstractBaseController
{
    private readonly IUserArticleBusiness _articleBusiness;
    private readonly ILogger<UserArticleController> _logger;

    public UserArticleController(IUserArticleBusiness articleBusiness, ILogger<UserArticleController> logger)
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
            var articles = await _articleBusiness.GetArticlesByCategoryId(CategoryId);
            if (articles.Count > 0)
            {
                return Ok(CreateResponse<List<Article>>(ServiceCode.GettingArticleSuccessful,
                MessageConstants.GettingArticlesSuccessful, articles));
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
