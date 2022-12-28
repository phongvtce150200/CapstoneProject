using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Configuration
{
    public class ScheduleDetailsConfig : IEntityTypeConfiguration<ScheduleDetails>
    {
        public void Configure(EntityTypeBuilder<ScheduleDetails> builder)
        {
            builder.ToTable("ScheduleDetails");
        }
    }
}
