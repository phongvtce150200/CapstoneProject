using BusinessObject.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BusinessObject.Entity
{
    public class Service : BaseEntity
    {
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }
    }
}
