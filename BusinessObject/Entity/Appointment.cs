using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Appointment : BaseEntity
    {
        [Required]
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        [Required]
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public Prescription Prescription { get; set; }
        public ReservedSchedule Schedule { get; set; }
        public decimal? SubTotal { get; set; }
        public Test Test { get; set; }
        public ICollection<AppointmentDetails> AppointmentDetails { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
