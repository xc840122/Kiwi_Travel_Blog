/// <summary>
/// Unified format of response
/// </summary>
/// <remarks>
/// response format for client http requests
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 08/10/2024
/// </author>
using OXL_Assessment2.Src.Constants;

namespace OXL_Assessment2.Src.Models;

public record ApiResponse<T>(string RequestID, ServiceCode Code, string Message, T Data);
