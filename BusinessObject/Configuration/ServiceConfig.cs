using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BusinessObject.Configuration
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");

            builder.Property(x => x.ServiceName).IsRequired().HasMaxLength(150);

            builder.Property(x => x.ServicePrice).IsRequired();
        }
    }
}
