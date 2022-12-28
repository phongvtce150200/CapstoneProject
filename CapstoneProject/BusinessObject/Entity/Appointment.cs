using BusinessObject.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Appointment : BaseEntity
    { 
    
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public Test Test { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<AppointmentDetails> AppointmentDetails { get; set; }
    }
}
