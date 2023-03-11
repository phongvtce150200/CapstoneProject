using BusinessObject.Entity;
using System;

namespace ClinicManageAPI.DTO.NurseDtos
{
    public class EditNurseInfoDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
