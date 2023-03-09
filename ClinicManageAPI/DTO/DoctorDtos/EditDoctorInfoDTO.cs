using BusinessObject.Entity;
using System;

namespace ClinicManageAPI.DTO.DoctorDtos
{
    public class EditDoctorInfoDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
