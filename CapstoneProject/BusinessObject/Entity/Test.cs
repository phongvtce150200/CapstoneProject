using BusinessObject.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Test : BaseEntity
    {
        public string MriImage { get; set; }
        public string Result { get; set; }
        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }
    }
}
