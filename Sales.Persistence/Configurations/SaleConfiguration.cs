using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Persistence.Configurations
{
  public class SaleConfiguration :
  IEntityTypeConfiguration<Sale>
  {
    public void Configure
    (
      EntityTypeBuilder<Sale> builder
    )
    {
      builder.HasData
      (
        new Sale
        {
          Id = 1,
          Amounth = 2,
          SaleDate = new DateTime(2022, 12, 31),
          BillId = 1
        },
        new Sale
        {
          Id = 2,
          Amounth = 1,
          SaleDate = new DateTime(2022, 6, 22),
          BillId = 2
        },
        new Sale
        {
          Id = 3,
          Amounth = 1,
          SaleDate = new DateTime(2022, 3, 16),
          BillId = 3
        },
        new Sale
        {
          Id = 4,
          Amounth = 3,
          SaleDate = new DateTime(2022, 8, 26),
          BillId = 4
        }
      );
    }
  }
}
