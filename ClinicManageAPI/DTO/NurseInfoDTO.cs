namespace ClinicManageAPI.DTO
{
    public class NurseInfoDTO
    {
        public string Id { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public UserInfoDTO User { get; set; }
    }
}
