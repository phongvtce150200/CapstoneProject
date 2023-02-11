using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BusinessObject.Seeder
{
    public static class MedicineSeedData
    {
        public static void SeedData(this EntityTypeBuilder<Medicine> builder)
        {
            var now = DateTime.UtcNow;
            builder.HasData(
                new Medicine { Id = 1, MedicineName = "Abacavir Sulfate", Price = 2000, Amount = 200 ,Description = "Non-Description" ,Expiration = now.AddYears(4), CreatedDate = now, IsDelete = false },
                new Medicine { Id = 2, MedicineName = "Acular", Price = 2000, Amount = 200, Description = "Non-Description", Expiration = now.AddYears(4), CreatedDate = now, IsDelete = false },
                new Medicine { Id = 3, MedicineName = "Adcirca", Price = 2000, Amount = 200, Description = "Non-Description", Expiration = now.AddYears(4), CreatedDate = now, IsDelete = false },
                new Medicine { Id = 4, MedicineName = "Betagan", Price = 2000, Amount = 200, Description = "Non-Description", Expiration = now.AddYears(4), CreatedDate = now, IsDelete = false },
                new Medicine { Id = 5, MedicineName = "Blocadren", Price = 2000, Amount = 200, Description = "Non-Description", Expiration = now.AddYears(4), CreatedDate = now, IsDelete = false },
                new Medicine { Id = 6, MedicineName = "Caverject", Price = 2000, Amount = 200, Description = "Non-Description", Expiration = now.AddYears(4), CreatedDate = now, IsDelete = false },
                new Medicine { Id = 7, MedicineName = "Copaxone", Price = 2000, Amount = 200, Description = "Non-Description", Expiration = now.AddYears(4), CreatedDate = now, IsDelete = false },
                new Medicine { Id = 8, MedicineName = "DesOwen", Price = 2000, Amount = 200, Description = "Non-Description", Expiration = now.AddYears(4), CreatedDate = now, IsDelete = false },
                new Medicine { Id = 9, MedicineName = "DesOwen", Price = 2000, Amount = 200, Description = "Non-Description", Expiration = now.AddYears(4), CreatedDate = now, IsDelete = false },
                new Medicine { Id = 10, MedicineName = "Fludara", Price = 2000, Amount = 200, Description = "Non-Description", Expiration = now.AddYears(4), CreatedDate = now, IsDelete = false });
        }
    }
}
