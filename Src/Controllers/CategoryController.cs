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
using Microsoft.AspNetCore.Mvc;
using OXL_Assessment2.DTOs;
using OXL_Assessment2.Interface;

namespace OXL_Assessment2.Src.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // unified message format of response
        private JsonResult FormatResponse(string requestId, int code, string message, object data)
        {
            return new JsonResult(new
            {
                requestID = requestId,
                code = code,
                message = message,
                data = data
            })
            {
                StatusCode = code // Set the HTTP status code in the response
            };
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return FormatResponse(Guid.NewGuid().ToString(), 200,
            "Get all categories successfully", categories);
        }
    }
}
