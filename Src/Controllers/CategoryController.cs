/// <summary>
/// category controller
/// </summary>
/// <remarks>
/// respond to clients
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 07/10/2024
/// </author>
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using OXL_Assessment2.Data.Entities;
using OXL_Assessment2.DTOs;
using OXL_Assessment2.Interface;
using OXL_Assessment2.Src.Constants;
using OXL_Assessment2.Src.Models;

namespace OXL_Assessment2.Src.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            // log the request information
            _logger.LogInformation("========GetAllCategories called========");
            if (categories != null)
            {
                return Ok(CreateResponse<List<CategoryDTO>>(ServiceCode.GetAllCategoriesSuccessfully,
                MessageConstants.GetCategoriesSuccessfully, categories));
            }
            else
            {
                return NotFound(CreateResponse<string>(ServiceCode.NoCategoriesFound,
                MessageConstants.NotFoundData, ""));
            }
        }
    }
}
