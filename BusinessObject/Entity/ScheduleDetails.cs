using BusinessObject.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class ScheduleDetails
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Key]
        public int ScheduleId { get; set; }
        [ForeignKey("ScheduleId")]
        public Schedule Schedule { get; set; }
    }
}
