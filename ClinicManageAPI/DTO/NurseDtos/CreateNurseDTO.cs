using System;

namespace ClinicManageAPI.DTO.NurseDtos
{
    public class CreateNurseDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public CreateNurseInfoDTO Nurse { get; set; }
    }
}
