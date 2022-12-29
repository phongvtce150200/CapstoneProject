using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BusinessObject.Seeder
{
    public static class ServiceSeedData
    {
        public static void SeedData(this EntityTypeBuilder<Service> builder)
        {
            var now = DateTime.UtcNow;
            builder.HasData(
                new Service { Id = 1, ServiceName = "Normal", ServicePrice = 250000, CreatedDate = now, IsDelete = false },
                new Service { Id = 2, ServiceName = "MRI scan", ServicePrice = 300000, CreatedDate = now, IsDelete = false },
                new Service { Id = 3, ServiceName = "General examination", ServicePrice = 500000, CreatedDate = now, IsDelete = false },
                new Service { Id = 4, ServiceName = "Detect Alzheimer's Disease", ServicePrice = 1000000, CreatedDate = now, IsDelete = false });
        }
    }
}
