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
    public class MRITechnicianConfig : IEntityTypeConfiguration<MRITechnician>
    {
        public void Configure(EntityTypeBuilder<MRITechnician> builder)
        {
            builder.ToTable("MRITechnician");
        }
    }
}
