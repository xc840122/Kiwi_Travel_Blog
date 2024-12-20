using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Businesses.IUserBusinesses;
using Kiwi_Travel_Blog.Src.Dtos.UserDtos.UserCreatingDtos;
using Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserGettingDtos;

namespace Kiwi_Travel_Blog.Src.Controllers.UserImpl;

/// <summary>
/// article controllers of user
/// </summary>
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
                return Ok(CreateResponse<List<UserGettingArticleDto>>(ServiceCode.GetArticlesSuccessfully,
                    MessageConstants.GettingArticlesSuccessful, new List<UserGettingArticleDto>()));
            }
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Error retrieving articles for category ID {categoryId}", categoryId);
            return StatusCode(500, CreateResponse(ServiceCode.InternalServerError,
                MessageConstants.OperationFailed));
        }
    }

    /// <summary>
    /// Interface to add an article, user must carry jwt token(signin) to add artile
    /// </summary>
    /// <param name="articleDto"></param>
    /// <returns></returns>
    [ModelStateVerification]
    [HttpPost]
    [Authorize]
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
            var articleId = await _articleBusiness.AddArticle(articleDto);
            if (articleId == -1)
            {
                _logger.LogWarning($"Get article failed after adding {articleDto.Name}");
                return BadRequest(CreateResponse(ServiceCode.GetArticleFailed, MessageConstants.GetArticleFailed));
            }

            return Ok(CreateResponse<long>(ServiceCode.AddArticleSuccessfully,
            MessageConstants.AddArticleSuccessfully, articleId));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Errors occurred while adding an article for name {articleDto.Name}");
            return StatusCode(500, CreateResponse(ServiceCode.InternalServerError,
                MessageConstants.OperationFailed));
        }
    }

    /// <summary>
    /// Get article detail by ID
    /// </summary>
    /// <param name="articleId"></param>
    /// <returns>article</returns>
    [HttpGet("{articleId}")]
    public async Task<IActionResult> GetArticle(long articleId)
    {
        try
        {
            var article = await _articleBusiness.GetArticle(articleId);
            if (article != null)
            {
                return Ok(CreateResponse<UserGettingArticleDetailDto>(ServiceCode.GetArticleDetailSuccessfully,
                    MessageConstants.GetArticleDetailSuccessfully, article));
            }
            else
            {
                _logger.LogWarning($"Article with ID {articleId} are not found");
                return NotFound(CreateResponse(ServiceCode.NoArticlesFound,
                    MessageConstants.NotFoundData));
            }
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, $"Error retrieving article for ID {articleId}");
            return StatusCode(500, CreateResponse(ServiceCode.InternalServerError,
                MessageConstants.OperationFailed));
        }
    }
}
