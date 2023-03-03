using ClinicManageAPI.DTO.UserDtos;

namespace ClinicManageAPI.DTO.DoctorDtos
{
    public class DoctorInfoDTO
    {
        public string Id { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public UserInfoDTO User { get; set; }
    }
}
