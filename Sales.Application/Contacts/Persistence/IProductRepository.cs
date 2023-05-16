using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Contacts.Persistence;
public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> GetProductsWithDetails();
    Task<Product> GetProductByIdWithDetails(int id);
}
