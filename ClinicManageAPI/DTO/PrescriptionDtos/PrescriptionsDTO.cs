using BusinessObject.Entity;
using ClinicManageAPI.DTO.AppointmentDtos;
using ClinicManageAPI.DTO.PrescriptionDetailDtos;
using System.Collections.Generic;

namespace ClinicManageAPI.DTO.PrescriptionDtos
{
    public class PrescriptionsDTO
    {
        public int AppointmentId { get; set; }
        
        public AppointmentPrescriptionDTO Appointment { get; set; }
        public ICollection<PrescriptionDetailDTO> PrescriptionDetails { get; set; }

    }
}
