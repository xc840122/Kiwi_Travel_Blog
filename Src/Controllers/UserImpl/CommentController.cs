using Kiwi_Travel_Blog.Src.Attributes;
using Kiwi_Travel_Blog.Src.Businesses.IUserBusinesses;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.DTOs.UserDtos.UserCreatingDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kiwi_Travel_Blog.Src.Controllers.UserImpl
{
    /// <summary>
    /// Comment controllers of user
    /// </summary>
    [Route("api/user/[controller]")]
    [ApiController]
    public class CommentController : AbstractBaseController
    {
        private readonly IUserCommentBusiness _commentBusiness;
        private readonly ILogger<CommentController> _logger;

        public CommentController(IUserCommentBusiness commentBusiness, ILogger<CommentController> logger)
        {
            _commentBusiness = commentBusiness;
            _logger = logger;
        }

        /// <summary>
        /// User post comment
        /// </summary>
        /// <param name="userCreatingCommentDto"></param>
        /// <returns></returns>
        [ModelStateVerification]
        [HttpPost()]
        public async Task<IActionResult> AddComment(UserCreatingCommentDto userCreatingCommentDto)
        {
            try
            {
                bool result = await _commentBusiness.AddComment(userCreatingCommentDto);
                if (result)
                {
                    return Ok(CreateResponse(ServiceCode.AddCommentSuccessfully,
                        MessageConstants.AddCommentSuccessfully));
                }
                else
                {
                    _logger.LogWarning("Failed to add comment");
                    return BadRequest(CreateResponse(ServiceCode.AddCommentFailed,
                        MessageConstants.AddCommentFailed));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Problem occuring while add comment{userCreatingCommentDto.Review}");
                return StatusCode(500, CreateResponse(ServiceCode.InternalServerError,
                MessageConstants.OperationFailed));
            }
        }
    }
}
