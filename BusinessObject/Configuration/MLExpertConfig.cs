using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Configuration
{
    public class MLExpertConfig : IEntityTypeConfiguration<MLExpert>
    {
        public void Configure(EntityTypeBuilder<MLExpert> builder)
        {
            builder.ToTable("MLExpert");
        }
    }
}
