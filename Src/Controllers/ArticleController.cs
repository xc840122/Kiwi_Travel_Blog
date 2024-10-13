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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : AbstractBaseController
    {
        private readonly IArticleService _articleService;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IArticleService articleService, ILogger<ArticleController> logger)
        {
            this._articleService = articleService;
            this._logger = logger;
        }

        [ModelStateVerification]
        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetArticlesByCategoryId(long CategoryId)
        {
            try
            {
                var articleDtos = await _articleService.GetArticlesByCategoryId(CategoryId);
                if (articleDtos != null)
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
