using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Medicine : BaseEntity
    {
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public DateTime Expiration { get; set; }
        public int InStock { get; set; }
        public string Description { get; set; }
        public ICollection<PrescriptionDetails> PrescriptionDetails { get; set; }
    }
}
