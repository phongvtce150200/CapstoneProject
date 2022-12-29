using System;

namespace ClinicManageAPI.DTO
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
