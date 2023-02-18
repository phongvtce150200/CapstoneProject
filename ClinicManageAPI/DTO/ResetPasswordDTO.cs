namespace ClinicManageAPI.DTO
{
    public class ResetPasswordDTO
    {
        public string token { get; set; }
        public string email { get; set; }
        public string password { get; set; } = null;
        public string confirmpassword { get; set; } = null;
    }
}
