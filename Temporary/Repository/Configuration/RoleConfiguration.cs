using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
	public void Configure(EntityTypeBuilder<IdentityRole> builder)
	{
		builder.HasData(
		  new IdentityRole
		  {
			  Name = "Doctor",
			  NormalizedName = "DOCTOR"
		  },
		  new IdentityRole
		  {
			  Name = "Patient",
			  NormalizedName = "PATIENT"
		  },
          new IdentityRole
          {
              Name = "Staff",
              NormalizedName = "STAFF"
          }
          ,
          new IdentityRole
          {
              Name = "Admin",
              NormalizedName = "ADMIN"
          }
        );
	}
}
