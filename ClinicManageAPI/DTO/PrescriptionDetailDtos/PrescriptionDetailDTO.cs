namespace ClinicManageAPI.DTO.PrescriptionDetailDtos
{
    public class PrescriptionDetailDTO
    {
        public int MedicineId { get; set; }
        public int MedicineAmount { get; set; }
        public string UsingDay { get; set; }
        public string TimesPerDay { get; set; }
        public string UsingType { get; set; }
        public int Session { get; set; }
        public string Description { get; set; }
    }

    
}
