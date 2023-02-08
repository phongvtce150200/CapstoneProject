using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObject.Configuration
{
    public class ReservedScheduleConfig : IEntityTypeConfiguration<ReservedSchedule>
    {
        public void Configure(EntityTypeBuilder<ReservedSchedule> builder)
        {
            builder.ToTable("ReservedSchedule");
        }
    }
}
