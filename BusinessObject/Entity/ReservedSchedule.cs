using BusinessObject.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class ReservedSchedule : BaseEntity
    {
        [Required]
        public int SlotId { get; set; }
        [Required]
        public int DocId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Start { get; set; }
        [Required]
        public string End { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set;}
        public ICollection<Appointment> appointments { get; set; }
    }
}
