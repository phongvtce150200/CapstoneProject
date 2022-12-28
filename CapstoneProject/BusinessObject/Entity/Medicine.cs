using BusinessObject.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Medicine : BaseEntity
    {
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public DateTime Expiration { get; set; }
        public string Description { get; set; }
        public int PrescriptionId { get; set; }
        [ForeignKey("PrescriptionId")]
        public Prescription Prescription { get; set; }
    }
}
