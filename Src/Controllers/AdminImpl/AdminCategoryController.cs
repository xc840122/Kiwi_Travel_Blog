using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Businesses.IAdminBusinesses;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kiwi_Travel_Blog.Src.Controllers.AdminImpl
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CategoriesController : AbstractBaseController
    {
        private readonly IAdminCategoryBusiness _categoryBusiness;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IAdminCategoryBusiness categoryBusiness, ILogger<CategoriesController> logger)
        {
            _categoryBusiness = categoryBusiness;
            _logger = logger;
        }
        [ModelStateVerification]
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    _logger.LogWarning("Category cannot be null");
                    return BadRequest(CreateResponse(ServiceCode.NullCategory, MessageConstants.NullCategory));
                }

                // TODO:Add logic to check duplicated name (code for business, repository)

                // Add category
                _logger.LogInformation($"Add category for name {categoryDto.Name}");
                await _categoryBusiness.AddCategory(categoryDto);

                return Ok(CreateResponse(ServiceCode.AddArticleSuccessfully, MessageConstants.AddCategorySuccessfully));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while adding category for name {categoryDto.Name}");
                throw;
            }
        }
    }
}
