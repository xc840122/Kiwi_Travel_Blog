using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Data.Entities;
using Kiwi_Travel_Blog.Src.Dtos;
using Kiwi_Travel_Blog.Src.Services.IServices;

namespace Kiwi_Travel_Blog.Src.Controllers
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
