using BusinessObject.Entity;
using System;

namespace ClinicManageAPI.DTO.DoctorDtos
{
    public class CreateDoctorDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public CreateDoctorInfoDTO Doctor { get; set; }
    }
}
