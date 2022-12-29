using BusinessObject.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObject.Seeder
{
    public static class RoleSeedData
    {
        public static void SeedData(this EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { Name = Roles.Admin, NormalizedName = Roles.Admin.ToUpper() },
                new IdentityRole { Name = Roles.Doctor, NormalizedName = Roles.Doctor.ToUpper() },
                new IdentityRole { Name = Roles.Nurse, NormalizedName = Roles.Nurse.ToUpper() },
                new IdentityRole { Name = Roles.Patient, NormalizedName = Roles.Patient.ToUpper() });
        }
    }
}
