using Microsoft.EntityFrameworkCore;
using Sales.Application.Contracts.Persistence;
using Sales.Domain.Entities;
using Sales.Persistence.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Persistence.Repositories;
public class CategoryRepository :
GenericRepository<Category>, ICategoryRepository
{
  public CategoryRepository(SalesDbContext context) : base(context)
  {
  }

  public async Task<List<Category>> GetCategoryWhitProducts()
  {
    var categoriesRequest = await context.Categories
      .Include(x => x.Products)
      .ToListAsync();

    return categoriesRequest;
  }

  public async Task<Category> GetCategoryWhitProducts(int id)
  {
    var categoryRequest = await context.Categories
      .Include(x => x.Products)
      .FirstOrDefaultAsync(x => x.Id == id);
    return categoryRequest;
  }
}
