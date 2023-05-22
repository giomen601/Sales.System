using Microsoft.EntityFrameworkCore;
using Sales.Application.Contracts.Persistence;
using Sales.Domain.Common;
using Sales.Domain.Entities;
using Sales.Persistence.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Persistence.Repositories;
public class ProductRepository :
GenericRepository<Product>, IProductRepository
{
    public ProductRepository(SalesDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetProductsWithDetails()
    {
        
        var productRequest = await context.Products
        .Include(x => x.Category)
        .ToListAsync();

        return productRequest;
    }

    public async Task<Product> GetProductByIdWithDetails(int id)
    {
      var productRequest = await context.Products
      .Include(x => x.Category)
      .FirstOrDefaultAsync(x => x.Id == id);

    return productRequest;
    }
}