using BusinessObject.Configuration;
using BusinessObject.Entity;
using BusinessObject.Seeder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace BusinessObject
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<AppointmentDetails> appointmentDetails { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Medicine> medicines { get; set; }
        public DbSet<Nurse> nurses { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }
        public DbSet<PrescriptionDetails> prescriptionDetails { get; set; }
        public DbSet<Queue> queues { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<ScheduleDetails> ScheduleDetails { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Test> tests { get; set; }
        public DbSet<Qualification> qualifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Defining a composite primary key
            builder.Entity<PrescriptionDetails>().HasKey(pd => new
            {
                pd.PrescriptionId,
                pd.MedicineId
            });
            builder.Entity<AppointmentDetails>().HasKey(ad => new
            {
                ad.AppointmentId,
                ad.ServiceId
            });

            //Remove AspNet in Indentity Table
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            //Modifying the delete behavior of foreign key relationships in a model
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Config Entity
            builder.ApplyConfiguration(new AppointmentConfig());
            builder.ApplyConfiguration(new AppointmentDetailsConfig());
            builder.ApplyConfiguration(new InvoiceConfig());
            builder.ApplyConfiguration(new MedicineConfig());
            builder.ApplyConfiguration(new PrescriptionConfig());
            builder.ApplyConfiguration(new QueueConfig());
            builder.ApplyConfiguration(new ScheduleConfig());
            builder.ApplyConfiguration(new ScheduleDetailsConfig());
            builder.ApplyConfiguration(new ServiceConfig());
            builder.ApplyConfiguration(new TestConfig());
            builder.ApplyConfiguration(new DoctorConfig());
            builder.ApplyConfiguration(new NurseConfig());
            builder.ApplyConfiguration(new PatientConfig());
            builder.ApplyConfiguration(new PrescriptionDetailsConfig());
            builder.ApplyConfiguration(new QualificationConfig());

            //Adding Seeder Data
            builder.Entity<Medicine>().SeedData();
            builder.Entity<Service>().SeedData();
            builder.Entity<User>().SeedData();
            builder.Entity<IdentityRole>().SeedData();
        }
    }
}
