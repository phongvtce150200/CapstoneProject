using ClinicManageAPI.DTO.ReservedScheduleDtos;

namespace ClinicManageAPI.DTO.AppointmentDtos
{
    public class AppointmentDTO
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public ReservedScheduleInfoDTO Schedule { get; set; }
    }
}
