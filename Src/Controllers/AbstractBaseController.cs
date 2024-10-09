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

        // Stadard method to generate response in controllers
        protected ApiResponse<T> CreateResponse<T>(ServiceCode code, string message, T data)
        {
            return new ApiResponse<T>(GetRequestId(), code, message, data);
        }
    }
}
