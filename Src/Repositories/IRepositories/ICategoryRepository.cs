/// <summary>
/// Interface of repository layer
/// </summary>
/// <remarks>
/// decouple repository and service
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 07/10/2024
/// </author>
using System;
using OXL_Assessment2.Data.Entities;

namespace OXL_Assessment2.Interface.IServices;

public interface ICategoryRepository
{
  // get all categories
  public List<Category> GetAllCategories();
}
