using BusinessObject.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BusinessObject.Seeder
{
    public static class UserSeedData
    {
        public static void SeedData(this EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var now = DateTime.UtcNow;
            builder.HasData(
                new User { UserName = "admin", FirstName = "admin", LastName = "admin", Gender = true, BirthDay = Convert.ToDateTime("01/01/1990"), Email = "admin@clinc.com", NormalizedEmail = "ADMIN@CLINIC.COM", EmailConfirmed = true, Address = "Admin", PhoneNumber = "0909090090", PhoneNumberConfirmed = true, NormalizedUserName = "ADMIN", PasswordHash = hasher.HashPassword(null, "admin@@"), CreatedDate = now, IsDelete = false },
                new User { UserName = "phongvt1712", FirstName = "Thanh Phong", LastName = "Võ", Gender = true, BirthDay = Convert.ToDateTime("02/01/2001"), Email = "v.thanhphong1712@gmail.com", NormalizedEmail = "V.THANHPHONG1712@GMAIL.COM", EmailConfirmed = true, Address = "TP HCM", PhoneNumber = "0769339456", PhoneNumberConfirmed = true, NormalizedUserName = "PHONGVT1712", PasswordHash = hasher.HashPassword(null, "123456"), CreatedDate = now, IsDelete = false },
                new User { UserName = "hungle", FirstName = "Quốc Hùng", LastName = "Lê", Gender = false, BirthDay = Convert.ToDateTime("02/01/2001"), Email = "hungle@gmail.com", NormalizedEmail = "HUNGLE@GMAIL.COM", EmailConfirmed = true, PhoneNumber = "0123456789", Address = "Cần Thơ", PhoneNumberConfirmed = true, NormalizedUserName = "HUNGLE", PasswordHash = hasher.HashPassword(null, "123456"), CreatedDate = now, IsDelete = false },
                new User { UserName = "hauphan", FirstName = "Công Hậu", LastName = "Phan", Gender = false, BirthDay = Convert.ToDateTime("01/01/2001"), Email = "hauphan@gmail.com", NormalizedEmail = "HAUPHAN@GMAIL.COM", EmailConfirmed = true, PhoneNumber = "0808080080", Address = "Bến Tre", PhoneNumberConfirmed = true, NormalizedUserName = "HAUPHAN", PasswordHash = hasher.HashPassword(null, "123456"), CreatedDate = now, IsDelete = false });
        }
    }
}
