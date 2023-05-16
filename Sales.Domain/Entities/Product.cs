using Sales.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities;
public class Product : BaseEntity
{
    public string? Description { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public List<ProductSale>? ProductsSales { get; set; }
}
