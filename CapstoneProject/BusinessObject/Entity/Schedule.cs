using BusinessObject.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Schedule : BaseEntity
    {
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public ICollection<ScheduleDetails> ScheduleDetails { get; set; }
    }
}
