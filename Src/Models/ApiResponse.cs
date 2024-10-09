using OXL_Assessment2.Src.Constants;


/// <summary>
/// Unified format of response
/// </summary>
/// <remarks>
/// response format for client http requests
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 08/10/2024
/// </author>
namespace OXL_Assessment2.Src.Models;

public record ApiResponse(string RequestID, ServiceCode Code, string Message, Object? Data);
