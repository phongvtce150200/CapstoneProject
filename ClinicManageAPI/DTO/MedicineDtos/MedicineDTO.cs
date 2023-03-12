using System;

namespace ClinicManageAPI.DTO.MedicineDtos
{
    public class MedicineDTO
    {
        public int Id { get; set; } 
        public string? MedicineName { get; set; }
        public decimal? Price { get; set; }
        public DateTime Expiration { get; set; }
        public int? InStock { get; set; }
        public string? Description { get; set; }
        public bool IsDelete { get; set; }
    }
}

