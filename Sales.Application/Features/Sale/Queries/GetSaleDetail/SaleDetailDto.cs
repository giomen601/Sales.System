using Sales.Application.Features.Product.Queries.GetAllProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sale.Queries.GetSaleDetail;
public class SaleDetailDto
{
  public int Amounth { get; set; }
  public DateTime SaleDate { get; set; }
  public List<ProductDto>? Products { get; set; }
}
