using Microsoft.EntityFrameworkCore;
using Sales.Application.Contracts.Persistence;
using Sales.Application.Features.Sale.Commands.UpdateSale;
using Sales.Domain.Entities;
using Sales.Persistence.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Persistence.Repositories;
public class SaleRepository :
  GenericRepository<Sale>, ISaleRepository
{
  public SaleRepository(SalesDbContext context) : base(context)
  {
  }

  public async Task<List<Sale>> GetSalesWithProducts()
  {
    
    var sales = await context.Sale
      .Include(x => x.ProductSales)
      .ThenInclude(x => x.Products)
      .ToListAsync();

    return sales;
  }

  public async Task<Sale> GetSalesByIdWhitProducts(int id)
  {
    var sale = await context.Sale
      .Include(x => x.ProductSales)
      .ThenInclude (x => x.Products)
      .FirstOrDefaultAsync(x => x.Id == id);

    return sale;
  }

  public async Task<Sale> UpdateSalesWithProducts(Sale sale, UpdateSaleCommand command)
  {
    //context.Entry(Sale).State = EntityState.Modified;
    context.Entry(sale).State = EntityState.Modified;
    var ProductSales = await context.ProductSales
      .Where(x => x.SaleId == sale.Id).ToListAsync();

    //Remove entries of productsales from data base
    foreach (var productsale in ProductSales)
    {
      context.Remove(productsale);
    }

    foreach (var productId in command.ProductsId)
    {
      context.Add
      (
        new ProductSale
        {
          ProductId = productId,
          SaleId = sale.Id
        }
      );
    }

    //Add new entries of productsales into de data base

    await context.SaveChangesAsync();
    return sale;
  }
}
