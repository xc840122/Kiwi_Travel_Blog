using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Dtos;
using Kiwi_Travel_Blog.Interface;

namespace Kiwi_Travel_Blog.Src.Controllers;
/// <summary>
/// category controllers of user
/// </summary>
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserCategoryController : AbstractBaseController
{
    private readonly ILogger<UserCategoryController> _logger;
    private readonly IUserCategoryBusiness _categoryBusiness;
    public UserCategoryController(ILogger<UserCategoryController> logger, IUserCategoryBusiness categoryBusiness)
    {
        _logger = logger;
        _categoryBusiness = categoryBusiness;
    }

    [ModelStateVerification]
    [HttpGet("all")]
    public IActionResult GetAllCategories()
    {
        var categories = _categoryBusiness.GetAllCategories();
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
