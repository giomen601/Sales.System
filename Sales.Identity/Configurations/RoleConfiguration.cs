using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sales.Identity.Configurations;
public class RoleConfiguration :
IEntityTypeConfiguration<IdentityRole>
{
  public void Configure(EntityTypeBuilder<IdentityRole> builder)
  {
    builder.HasData
    (
      new IdentityRole
      {
        Id = "1dbacb79-2fcb-464d-bd3b-8e4e944c476e",
        Name = "Administrator",
        NormalizedName = "ADMINISTRATOR"
      },
      new IdentityRole
      {
        Id = "2c73effd-16ce-4f7e-9afe-05fe0dbd9814",
        Name = "User",
        NormalizedName = "USER"
      }
    );
  }
}