using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObject.Configuration
{
    public class PrescriptionDetailsConfig : IEntityTypeConfiguration<PrescriptionDetails>
    {
        public void Configure(EntityTypeBuilder<PrescriptionDetails> builder)
        {
            builder.ToTable("PrescriptionDetails");
        }
    }
}
