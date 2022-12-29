using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class AppointmentDetails
    {
        [Key]
        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }
        [Key]
        public int ServiceId { get; set; }
        [ForeignKey(("ServiceId"))]
        public Service Service { get; set; }
        public string Reason { get; set; }
    }
}
