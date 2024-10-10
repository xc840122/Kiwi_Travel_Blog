/// <summary>
/// Base controller to handle unified logic
/// </summary>
/// <remarks>
/// 1. insert the request id
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 09/10/2024
/// </author>
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OXL_Assessment2.Src.Constants;
using OXL_Assessment2.Src.Models;

namespace OXL_Assessment2.Src.Controllers
{
    public abstract class AbstractBaseController : ControllerBase
    {
        // Get the RequestID from the HttpContext set by the middleware (add new one if null)
        protected string GetRequestId()
        {
            return HttpContext.Items["RequestID"]?.ToString() ?? Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Create response with data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected ApiResponseModel<T> CreateResponse<T>(ServiceCode code, string message, T data)
        {
            return new ApiResponseModel<T>(GetRequestId(), code, message, data);
        }

        /// <summary>
        /// Create response without data
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ApiResponseModel CreateResponse(ServiceCode code, string message)
        {
            return new ApiResponseModel(GetRequestId(), code, message);
        }
    }
}
