using Sales.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities;
public class Category : BaseEntity
{
    public string? Description { get; set; }
    public List<Product>? Products { get; set; }
}
