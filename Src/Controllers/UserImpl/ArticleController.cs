using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Businesses.IArticleBusiness;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Dtos;

namespace Kiwi_Travel_Blog.Src.Controllers;

/// <summary>
/// article controllers of user
/// </summary>
[Authorize]
[Route("api/user/[controller]")]
[ApiController]
public class ArticleController : AbstractBaseController
{
    private readonly IUserArticleBusiness _articleBusiness;
    private readonly ILogger<ArticleController> _logger;

    public ArticleController(IUserArticleBusiness articleBusiness, ILogger<ArticleController> logger)
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
                return Ok(CreateResponse<List<Article>>(ServiceCode.GetArticlesSuccessfully,
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
    /// <summary>
    /// Interface to add an article
    /// </summary>
    /// <param name="articleDto"></param>
    /// <returns></returns>
    [ModelStateVerification]
    [HttpPost]
    public async Task<IActionResult> AddArticle([FromBody] ArticleDto articleDto)
    {
        try
        {
            if (articleDto == null)
            {
                _logger.LogWarning("Article cannot be null");
                return BadRequest(CreateResponse(ServiceCode.NullArticle, MessageConstants.NullArticle));
            }
            // Call business method to add article
            await _articleBusiness.AddArticle(articleDto);
            _logger.LogInformation($"Add an article for name {articleDto.Name}");

            return Ok(CreateResponse(ServiceCode.AddArticleSuccessfully, MessageConstants.AddArticleSuccessfully));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Errors occurred while adding an article for name {articleDto.Name}");
            throw;
        }
    }
}
