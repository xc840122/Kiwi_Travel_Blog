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
  // 1xxx, registration relavant
  RegistrationSuccessful = 100001,
  RegistrationFailed = 100002,
  // 2xxx category relavant
  GettingAllCategoriesSuccessful = 200001,
  NoCategoriesFound = 200002,
  // 3xxx login relavant
  LoginSuccessful = 300001,
  UserNotExist = 300002,
  PasswordNotCorrect = 300003,
}
