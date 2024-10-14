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
using Kiwi_Travel_Blog.Data.Entities;

namespace Kiwi_Travel_Blog.Interface.IServices;

public interface ICategoryRepository
{
  // get all categories
  public List<Category> GetAllCategories();
}
