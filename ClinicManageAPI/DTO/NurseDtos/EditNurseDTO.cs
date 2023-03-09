namespace ClinicManageAPI.DTO.NurseDtos
{
    public class EditNurseDTO
    {
        public int Id { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public EditNurseInfoDTO User { get; set; }
    }
}
