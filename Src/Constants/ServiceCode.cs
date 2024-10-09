/// <summary>
/// code list of http response
/// </summary>
/// <remarks>
/// each code maps service operation
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 09/10/2024
/// </author>
namespace OXL_Assessment2.Src.Constants;

public enum ServiceCode
{
  // 1xxx
  RegisterSuccessfully = 100001,
  // 2xxx category relavant
  GetAllCategoriesSuccessfully = 200001,
  NoCategoriesFound = 200002,
}
