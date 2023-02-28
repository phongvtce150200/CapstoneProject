using BusinessObject.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Queue : BaseEntity
    {
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int? Pulse { get; set; }
        public int? BloodPressure { get; set; }
        public int? Tempurature { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
    }
}
