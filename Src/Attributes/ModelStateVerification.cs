/// <summary>
/// ModelStateVerificationAttribute, used to verify ModelState of controllers
/// </summary>
/// <remarks>
/// ModelStateVerificationAttribute, used to verify ModelState of controllers
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 10/10/2024
/// </author>
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kiwi_Travel_Blog.Src.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ModelStateVerificationAttribute : ActionFilterAttribute
{
  public override void OnActionExecuting(ActionExecutingContext context)
  {
    if (!context.ModelState.IsValid)
    {
      context.Result = new BadRequestObjectResult(context.ModelState);
    }
  }
}
