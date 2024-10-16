using Kiwi_Travel_Blog.Src.Constants;

namespace Kiwi_Travel_Blog.Src.Models;
/// <summary>
/// for response with data
/// </summary>
/// <typeparam name="TData"></typeparam>
/// <param name="RequestID"></param>
/// <param name="Code"></param>
/// <param name="Message"></param>
/// <param name="Data"></param>
public record ApiResponseModel<TData>(string RequestID, ServiceCode Code, string Message, TData data);


/// <summary>
/// for response without data
/// </summary>
/// <param name="RequestID"></param>
/// <param name="Code"></param>
/// <param name="Message"></param>
public record ApiResponseModel(string RequestID, ServiceCode Code, string Message);
