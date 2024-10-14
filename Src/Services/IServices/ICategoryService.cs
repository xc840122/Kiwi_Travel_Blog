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
using Kiwi_Travel_Blog.Src.Dtos;

namespace Kiwi_Travel_Blog.Interface;

public interface ICategoryService
{
  public List<CategoryDto> GetAllCategories();
}
