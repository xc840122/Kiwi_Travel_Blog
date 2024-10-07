/// <summary>
/// category repository
/// </summary>
/// <remarks>
/// operate category data from database
/// </remarks>
/// <author>
/// Chi Xu (Peter) -- 07/10/2024
/// </author>
using System;
using OXL_Assessment2.Data;
using OXL_Assessment2.Data.Entities;
using OXL_Assessment2.Interface.IServices;

namespace OXL_Assessment2.Src.Repositories;

public class CategoryRepository : ICategoryRepository
{
  private readonly AppDbContext _context;

  public CategoryRepository(AppDbContext context)
  {
    _context = context;
  }
  public List<Category> GetAllCategories()
  {
    return _context.Categories.ToList();
  }
}
