using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Businesses.IUserBusinesses;
using Kiwi_Travel_Blog.Src.Dtos.UserDtos.UserCreatingDtos;
using Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserGettingDtos;

namespace Kiwi_Travel_Blog.Src.Controllers.UserImpl;

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
    /// <param name="categoryId"></param>
    /// <returns>list of article dto</returns>
    [ModelStateVerification]
    [HttpGet()]
    public async Task<IActionResult> GetArticlesByCategoryId([FromQuery] long categoryId)
    {
        try
        {
            var articles = await _articleBusiness.GetArticlesByCategoryId(categoryId);
            if (articles != null && articles.Any())
            {
                return Ok(CreateResponse<List<UserGettingArticleDto>>(ServiceCode.GetArticlesSuccessfully,
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
            _logger.LogError(ex, "Error retrieving articles for category ID {categoryId}", categoryId);
            return StatusCode(500, CreateResponse(ServiceCode.InternalServerError,
                MessageConstants.FailedGettingArticles));
        }
    }

    /// <summary>
    /// Interface to add an article
    /// </summary>
    /// <param name="articleDto"></param>
    /// <returns></returns>
    [ModelStateVerification]
    [HttpPost]
    public async Task<IActionResult> AddArticle([FromBody] UserCreatingArticleDto articleDto)
    {
        try
        {
            // Check nullable
            if (articleDto == null)
            {
                _logger.LogWarning("Article cannot be null");
                return BadRequest(CreateResponse(ServiceCode.NullArticle, MessageConstants.NullArticle));
            }

            // Set author(username)
            articleDto.Author = HttpContext.Items["UserName"]?.ToString() ?? string.Empty;
            // Check non-nullable username
            if (string.IsNullOrEmpty(articleDto.Author))
            {
                _logger.LogWarning("Username cannot be null");
                return BadRequest(CreateResponse(ServiceCode.NullUserName, MessageConstants.NullUserName));
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
