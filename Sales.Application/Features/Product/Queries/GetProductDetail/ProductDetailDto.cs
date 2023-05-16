using Sales.Application.Features.Category.Queries.GetAllCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Product.Queries.GetProductDetail;
public class ProductDetailDto
{
    public string? Description { get; set; }
    public double Price { get; set; }
  public CategoryDto? Category { get; set; }
}