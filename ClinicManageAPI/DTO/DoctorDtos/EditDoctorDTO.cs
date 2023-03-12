using BusinessObject.Entity;
using System;

namespace ClinicManageAPI.DTO.DoctorDtos
{
    public class EditDoctorDTO
    {
        public int Id { get; set; }
        public int Experience { get; set; }
        public EditDoctorInfoDTO User { get; set; }
    }
}
