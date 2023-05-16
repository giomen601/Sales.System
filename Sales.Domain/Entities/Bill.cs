using Sales.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities;
public class Bill : BaseEntity
{
    public DateTime Date { get; set; }
    public string? ClientId { get; set; }
    //TODO
    //public IdentityUser User { get; set; }
}
