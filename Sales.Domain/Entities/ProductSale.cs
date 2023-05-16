using Sales.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities;
public class ProductSale
{
  public int ProductId { get; set; }
  public int SaleId { get; set; }
  public Product? Products { get; set; }
  public Sale? Sales { get; set; }
}