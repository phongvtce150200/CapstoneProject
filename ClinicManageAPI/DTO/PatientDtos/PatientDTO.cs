using ClinicManageAPI.DTO.UserDtos;

namespace ClinicManageAPI.DTO.PatientDtos
{
    public class PatientDTO
    {
        public string Id { get; set; }
        public UserInfoDTO User { get; set; }
    }
}
