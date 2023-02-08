using BusinessObject.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Appointment : BaseEntity
    { 
    
        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public ReservedSchedule Schedule { get; set; }
        public Test Test { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<AppointmentDetails> AppointmentDetails { get; set; }
    }
}
