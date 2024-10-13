using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OXL_Assessment2.Src.Attributes;
using OXL_Assessment2.Src.Constants;
using OXL_Assessment2.Src.Data.Entities;
using OXL_Assessment2.Src.Dtos;
using OXL_Assessment2.Src.Services.IServices;

namespace OXL_Assessment2.Src.Controllers
{
    /// <summary>
    /// article controller
    /// </summary>

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : AbstractBaseController
    {
        private readonly IArticleService _articleService;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IArticleService articleService, ILogger<ArticleController> logger)
        {
            _articleService = articleService;
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
                var articleDtos = await _articleService.GetArticlesByCategoryId(CategoryId);
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
}
