using BusinessObject.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class ScheduleDetails : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; }
    }
}
