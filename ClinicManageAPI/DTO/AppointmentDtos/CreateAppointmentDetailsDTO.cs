using System.Collections.Generic;

namespace ClinicManageAPI.DTO.AppointmentDtos
{
    public class CreateAppointmentDetailsDTO
    {
        public int? ServiceId { get; set; }
        public string? Reason { get; set; }
        public decimal? SubTotal { get; set; }
    }
}
