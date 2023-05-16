using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Persistence.DbContext;
public class SalesDbContext : Microsoft.EntityFrameworkCore.DbContext
{
  public SalesDbContext
  (
      DbContextOptions<SalesDbContext> options
  ) : base( options )
  {
        
  }

  public DbSet<Product> Products{ get; set; }
  public DbSet<Category> Categories{ get; set; }
  public DbSet<Sale> Sale { get; set; }
  public DbSet<Bill> Bills { get; set; }
  public DbSet<ProductSale> ProductSales { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesDbContext).Assembly);
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<ProductSale>()
      .HasKey(PS => new { PS.ProductId, PS.SaleId });
  }
}