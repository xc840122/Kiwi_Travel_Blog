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
/// <typeparam name="TData"></typeparam>
/// <param name="RequestID"></param>
/// <param name="Code"></param>
/// <param name="Message"></param>
/// <param name="Data"></param>
public record ApiResponseModel<TData>(string RequestID, ServiceCode Code, string Message, TData Data);
/// <summary>
/// for response without data
/// </summary>
/// <param name="RequestID"></param>
/// <param name="Code"></param>
/// <param name="Message"></param>
public record ApiResponseModel(string RequestID, ServiceCode Code, string Message);
