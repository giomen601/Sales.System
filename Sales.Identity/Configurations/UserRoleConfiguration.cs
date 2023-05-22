using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Identity.Configurations;
public class UserRoleConfiguration :
IEntityTypeConfiguration<IdentityUserRole<string>>
{
  public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
  {
    builder.HasData
    (
      new IdentityUserRole<string>
      {
        RoleId = "1dbacb79-2fcb-464d-bd3b-8e4e944c476e",
        UserId = "e99152f0-c0a2-4d5e-aed1-d16b572a1958"
      },
      new IdentityUserRole<string>
      {
        RoleId = "2c73effd-16ce-4f7e-9afe-05fe0dbd9814",
        UserId = "3448c42a-423d-4e76-a7e7-71d25ead018b"
      }
    );
  }
}
