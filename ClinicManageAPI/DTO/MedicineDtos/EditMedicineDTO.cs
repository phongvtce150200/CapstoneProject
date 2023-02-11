using System;

namespace ClinicManageAPI.DTO.MedicineDtos
{
    public class EditMedicineDTO
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public DateTime Expiration { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
