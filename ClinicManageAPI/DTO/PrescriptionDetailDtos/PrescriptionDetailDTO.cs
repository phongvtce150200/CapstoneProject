using BusinessObject.Entity;
using ClinicManageAPI.DTO.MedicineDtos;

namespace ClinicManageAPI.DTO.PrescriptionDetailDtos
{
    public class PrescriptionDetailDTO
    {
        public MedicineDTO Medicine { get; set; }
        public int? MedicineAmount { get; set; }
        public string? UsingDay { get; set; }
        public string? TimesPerDay { get; set; }
        public string? UsingType { get; set; }
        public Session Session { get; set; }
        public string? Description { get; set; }
    }

    
}
