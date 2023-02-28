using BusinessObject.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Invoice : BaseEntity
    {
        public string Description { get; set; }
        public int PresciptionId { get; set; }
        [ForeignKey("PresciptionId")]
        public Prescription Prescription { get; set; }
    }
}
