using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class ReservedSchedule : BaseEntity
    {
        [Required]
        public int? DocId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        /*public ICollection<Appointment> appointments { get; set; }*/
        public int? appointmentId { get; set; }
        [ForeignKey("appointmentId")]
        public Appointment Appointment { get; set; }
    }
}
