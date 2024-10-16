using Microsoft.AspNetCore.Mvc;
using Kiwi_Travel_Blog.Src.Constants;
using Kiwi_Travel_Blog.Src.Models;

namespace Kiwi_Travel_Blog.Src.Controllers
{
    /// <summary>
    /// Abstract class for common method
    /// </summary>
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
        /// <typeparam name="TData"></typeparam>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected ApiResponseModel<TData> CreateResponse<TData>(ServiceCode code, string message, TData data)
        {
            return new ApiResponseModel<TData>(GetRequestId(), code, message, data);
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
