/// <summary>
/// category controller
/// </summary>
/// <remarks>
/// respond to clients
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 07/10/2024
/// </author>
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using OXL_Assessment2.Interface;
using OXL_Assessment2.Src.Attributes;
using OXL_Assessment2.Src.Constants;
using OXL_Assessment2.Src.Dtos;

namespace OXL_Assessment2.Src.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : AbstractBaseController
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [ModelStateVerification]
        [HttpGet("all")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            // log the request information
            _logger.LogInformation("========GetAllCategories called========");
            if (categories != null)
            {
                return Ok(CreateResponse<List<CategoryDto>>(ServiceCode.GettingAllCategoriesSuccessful,
                MessageConstants.GettingAllCategoriesSuccessful, categories));
            }
            else
            {
                _logger.LogWarning("Categories are not found");
                return NotFound(CreateResponse(ServiceCode.NoCategoriesFound,
                MessageConstants.NotFoundData));
            }
        }
    }
}
