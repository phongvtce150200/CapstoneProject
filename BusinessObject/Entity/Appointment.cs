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
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        [Required]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public ReservedSchedule Schedule { get; set; }
        public Test Test { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<AppointmentDetails> AppointmentDetails { get; set; }
    }
}
