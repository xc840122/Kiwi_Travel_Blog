using System;

namespace OXL_Assessment2.Src.Models;
/// <summary>
/// model of pagination
/// </summary>
public class PaginationModel
{
  public int Page { get; set; }
  public int PageSize { get; set; }
  public int TotalRecords { get; set; }
  public int TotalPages { get; set; }
  public bool HasNextPage { get; set; }
  public bool HasPreviousPage { get; set; }
}
