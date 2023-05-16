using Sales.Application.Features.Sale.Commands.UpdateSale;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Contacts.Persistence;
public interface ISaleRepository : IGenericRepository<Sale>
{
  Task<List<Sale>> GetSalesWithProducts();
  Task<Sale> GetSalesByIdWhitProducts(int id);
  Task<Sale> UpdateSalesWithProducts(Sale sale, UpdateSaleCommand command);
}
