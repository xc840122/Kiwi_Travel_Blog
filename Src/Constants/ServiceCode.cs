namespace Kiwi_Travel_Blog.Src.Constants;
/// <summary>
/// service code of user
/// </summary>
public enum ServiceCode
{
  // first digit means role(1:user,2:admin), second digit means service type
  // Code for user
  // 11xxx, registration relavant
  RegistrationSuccessful = 11001,
  RegistrationFailed = 11002,
  // 12xxx login relavant
  LoginSuccessfully = 12001,
  UserNotExist = 12002,
  PasswordNotCorrect = 12003,
  // 13xxx category relavant
  GettAllCategoriesSuccessfully = 13001,
  NoCategoriesFound = 13002,
  // 14xxx article relavant
  GetArticlesSuccessfully = 14001,
  NoArticlesFound = 14002,
  AddArticleSuccessfully = 14003,
  NullArticle = 14004,
  GetArticleDetailSuccessfully = 14005,
  GetArticleFailed = 14006,
  // 15xxx user relavant
  NullUserName = 15001,

  // 16xxx comment relavant
  AddCommentSuccessfully = 16001,
  AddCommentFailed = 16002,

  // Code for admin
  // 23xxx category relavant
  AddingCategorySuccessful = 23001,
  NullCategory = 23002,

  // Common
  InternalServerError = 31001
}
