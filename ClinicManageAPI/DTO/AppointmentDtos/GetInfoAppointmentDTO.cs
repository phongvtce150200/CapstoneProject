using ClinicManageAPI.DTO.DoctorDtos;
using ClinicManageAPI.DTO.PatientDtos;
using System;

namespace ClinicManageAPI.DTO.AppointmentDtos
{
    public class GetInfoAppointmentDTO
    {
        public int Id { get; set; } 
        public DoctorInfoDTO Doctor { get; set; }
        public PatientInfoDTO Patient { get; set; }    
        public DateTime CreatedDate { get; set; }
    }
}
