using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Persistence.Configurations;
public class ProductSaleConfiguration :
IEntityTypeConfiguration<ProductSale>
{
  public void Configure
  (
    EntityTypeBuilder<ProductSale> builder
  )
  {
    builder.HasData
    (
      new ProductSale
      {
        ProductId = 1,
        SaleId = 1,
      },
      new ProductSale
      {
        ProductId = 2,
        SaleId = 2,
      },
      new ProductSale
      {
        ProductId = 3,
        SaleId = 3,
      },
      new ProductSale
      {
        ProductId = 3,
        SaleId = 4,
      },
      new ProductSale
      {
        ProductId = 2,
        SaleId = 4
      }
    );
  }
}
