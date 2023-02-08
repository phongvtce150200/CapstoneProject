namespace ClinicManageAPI.DTO
{
    public class ReservedScheduleDTO
    {
        public int Id { get; set; }
        public int DocId { get; set; }
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}
