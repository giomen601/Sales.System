using Sales.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities;
public class Supplier : BaseEntity
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int Phone { get; set; }
}
