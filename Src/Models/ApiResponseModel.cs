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
/// <summary>
/// for response with data
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="RequestID"></param>
/// <param name="Code"></param>
/// <param name="Message"></param>
/// <param name="Data"></param>
public record ApiResponseModel<T>(string RequestID, ServiceCode Code, string Message, T Data);
/// <summary>
/// for response without data
/// </summary>
/// <param name="RequestID"></param>
/// <param name="Code"></param>
/// <param name="Message"></param>
public record ApiResponseModel(string RequestID, ServiceCode Code, string Message);
