/// <summary>
/// Interface of category service
/// </summary>
/// <remarks>
/// decouple controller of service
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 07/10/2024
/// </author>
using System;
using Microsoft.AspNetCore.Mvc;
using OXL_Assessment2.DTOs;

namespace OXL_Assessment2.Interface;

public interface ICategoryService
{
  public List<CategoryDTO> GetAllCategories();
}
