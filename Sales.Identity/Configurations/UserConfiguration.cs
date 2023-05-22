using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Identity.Configurations;
public class UserConfiguration :
IEntityTypeConfiguration<ApplicationUser>
{
  public void Configure(EntityTypeBuilder<ApplicationUser> builder)
  {
    var haser = new PasswordHasher<ApplicationUser>();

    builder.HasData
    (
      new ApplicationUser
      {
        Id = "e99152f0-c0a2-4d5e-aed1-d16b572a1958",
        Email = "admin@localhost.com",
        NormalizedEmail = "ADMIN@LOCALHOST.COM",
        UserName = "admin@localhost.com",
        NormalizedUserName = "ADMIN@LOCALHOST.COM",
        PasswordHash = haser.HashPassword(null, "P@ssword1"),
        EmailConfirmed = true
      },
      new ApplicationUser
      {
        Id = "3448c42a-423d-4e76-a7e7-71d25ead018b",
        Email = "user@localhost.com",
        NormalizedEmail = "USER@LOCALHOST.COM",
        UserName = "user@localhost.com",
        NormalizedUserName = "USER@LOCALHOST.COM",
        PasswordHash = haser.HashPassword(null, "P@ssword2"),
        EmailConfirmed = true
      }
    );
  }
}
