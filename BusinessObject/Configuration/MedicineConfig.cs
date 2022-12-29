using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObject.Configuration
{
    public class MedicineConfig : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.ToTable("Medicine");

            builder.Property(x => x.MedicineName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
        }
    }
}
