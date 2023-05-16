using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Persistence.Configurations;
public class ProductConfiguration :
IEntityTypeConfiguration<Product>
{
  public void Configure
  (
    EntityTypeBuilder<Product> builder
  )
  {
    builder.HasData
    (
      new Product
      {
        Id = 1,
        Description = "First Product to be created",
        Price = 666,
        CategoryId = 1,
      },
      new Product
      {
        Id = 2,
        Description = "Second Product to be created",
        Price = 667,
        CategoryId = 2,
      },
      new Product
      {
        Id = 3,
        Description = "Third Product to be created",
        Price = 668,
        CategoryId = 2,
      },
      new Product
      {
        Id = 4,
        Description = "Four Product to be created",
        Price = 669,
        CategoryId = 3,
      }
    );
  }
}