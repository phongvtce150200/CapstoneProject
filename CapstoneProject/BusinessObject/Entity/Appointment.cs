using BusinessObject.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Appointment : BaseEntity
    { 
        public string Reason { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public Test Test { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<Service> services { get; set; }
    }
}
