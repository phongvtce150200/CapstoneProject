using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObject.Configuration
{
    public class TestConfig : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.ToTable("Test");

            builder.Property(x => x.MriImage).IsRequired();

            builder.Property(x => x.Result).IsRequired().HasMaxLength(150);
        }
    }
}
