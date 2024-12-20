using System;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Kiwi_Travel_Blog.Src.Constants;
/// <summary>
/// Message for user
/// </summary>
public class MessageConstants
{
  // Messages for user
  // Registration
  public const string RegistrationSuccessful = "Registration Successful";
  public const string RegistrationFailed = "Registration failed";
  // Login
  public const string UserNotExist = "User not existed";
  public const string PasswordNotCorrect = "Password not correct";
  public const string LoginSuccessfully = "Login successfully";
  // Category
  public const string GetAllCategoriesSuccessfully = "Get all categories successfully";
  // Article
  public const string GettingArticlesSuccessful = "Getting articles successful";
  public const string AddArticleSuccessfully = "Add an article successfully";
  public const string NullArticle = "Null article";
  public const string GetArticleDetailSuccessfully = "Get Article Detail Successfully";
  public const string GetArticleFailed = "Get Article Failed";
  // User
  public const string NullUserName = "Null username";
  // Comment
  public const string AddCommentSuccessfully = "Add Comment Successfully";
  public const string AddCommentFailed = "Add Comment Failed";
  // Common
  public const string NotFoundData = "Not found data";
  public const string NotConfigureKey = "Not configure key";
  public const string OperationFailed = "Operation Failed";

  // Messages for admin
  // Category
  public const string AddCategorySuccessfully = "Add Category Successfully";
  public const string NullCategory = "Null Category";
}
