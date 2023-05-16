using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Persistence.Configurations;
public class CategoryConfiguration :
IEntityTypeConfiguration<Category>
{
  public void Configure
  (
    EntityTypeBuilder<Category> builder
  )
  {
    builder.HasData
    (
      new Category
      {
        Id = 1,
        Description = "First category"
      },
      new Category
      {
        Id = 2,
        Description = "Second category"
      },
      new Category
      {
        Id = 3,
        Description = "Third category"
      }
    );
  }
}
