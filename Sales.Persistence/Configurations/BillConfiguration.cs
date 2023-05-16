using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Persistence.Configurations;
public class BillConfiguration :
IEntityTypeConfiguration<Bill>
{
  public void Configure
  (
    EntityTypeBuilder<Bill> builder
  )
  {
    builder.HasData
    (
      new Bill
      {
        Id = 1,
        Date = new DateTime(2022, 1, 22),
        ClientId = "PrubId"
      },
      new Bill
      {
        Id = 2,
        Date = new DateTime(2022, 2, 22),
        ClientId = "PrubId"
      },
      new Bill
      {
        Id = 3,
        Date = new DateTime(2022, 3, 22),
        ClientId = "PrubId"
      },
      new Bill
      {
        Id = 4,
        Date = new DateTime(2022, 4, 22),
        ClientId = "PrubId"
      }
    );
  }
}
