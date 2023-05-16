using Sales.Application.Features.Product.Queries.GetAllProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Category.Queries.GetAllCategories;
public class CategoryDto
{
  public string? Description { get; set; }
  public List<ProductDto>? Products { get; set; }
}
