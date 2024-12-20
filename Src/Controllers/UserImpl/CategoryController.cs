using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Businesses.IUserBusinesses;
using Kiwi_Travel_Blog.Src.Dtos.UserDtos.UserGettingDtos;

namespace Kiwi_Travel_Blog.Src.Controllers.UserImpl;
/// <summary>
/// category controllers of user
/// </summary>
[Route("api/user/[controller]")]
[ApiController]
public class CategoryController : AbstractBaseController
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IUserCategoryBusiness _categoryBusiness;
    public CategoryController(ILogger<CategoryController> logger, IUserCategoryBusiness categoryBusiness)
    {
        _logger = logger;
        _categoryBusiness = categoryBusiness;
    }
    /// <summary>
    /// Get all categories
    /// </summary>
    /// <returns></returns>
    [ModelStateVerification]
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCategories()
    {
        try
        {
            var categories = await _categoryBusiness.GetAllCategories();
            // log the request information
            _logger.LogInformation("========GetAllCategories called========");
            if (categories != null)
            {
                return Ok(CreateResponse<List<UserGettingCategoryDto>>(ServiceCode.GettAllCategoriesSuccessfully,
                MessageConstants.GetAllCategoriesSuccessfully, categories));
            }
            else
            {
                _logger.LogWarning("Categories are not found");
                return NotFound(CreateResponse(ServiceCode.NoCategoriesFound,
                MessageConstants.NotFoundData));
            }
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Error retrieving all caterories");
            throw;
        }
    }
}
