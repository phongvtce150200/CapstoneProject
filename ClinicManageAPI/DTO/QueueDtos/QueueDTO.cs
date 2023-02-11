using System;

namespace ClinicManageAPI.DTO.QueueDtos
{
    public class QueueDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int Pulse { get; set; }
        public int BloodPressure { get; set; }
        public int Tempurature { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
    }
}
