using BusinessObject.Entity;
using ClinicManageAPI.DTO.AppointmentDtos;
using ClinicManageAPI.DTO.PrescriptionDetailDtos;
using System;
using System.Collections.Generic;

namespace ClinicManageAPI.DTO.PrescriptionDtos
{
    public class PrescriptionsDTO
    {
        public int Id { get; set; } 
        public int AppointmentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<PrescriptionDetailDTO> PrescriptionDetails { get; set; }
    }
}
