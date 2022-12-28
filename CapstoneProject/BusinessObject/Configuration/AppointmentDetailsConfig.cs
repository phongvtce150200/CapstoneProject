using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObject.Configuration
{
    public class AppointmentDetailsConfig : IEntityTypeConfiguration<AppointmentDetails>
    {
        public void Configure(EntityTypeBuilder<AppointmentDetails> builder)
        {
            builder.ToTable("AppointmentDetails");

            builder.Property(x => x.Reason).IsRequired().HasMaxLength(150);
            
        }
    }
}
