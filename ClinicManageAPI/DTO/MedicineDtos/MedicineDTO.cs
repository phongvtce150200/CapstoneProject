using System;

namespace ClinicManageAPI.DTO.MedicineDtos
{
    public class MedicineDTO
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public DateTime Expiration { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

