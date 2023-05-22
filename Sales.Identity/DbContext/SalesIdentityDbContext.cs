using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sales.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Identity.DbContext;
public class SalesIdentityDbContext : IdentityDbContext<ApplicationUser>
{
  public SalesIdentityDbContext
  (
    DbContextOptions<SalesIdentityDbContext> options
  ) : base( options )
  {
  
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    builder.ApplyConfigurationsFromAssembly
    (
      typeof(SalesIdentityDbContext).Assembly
    );
  }
}
