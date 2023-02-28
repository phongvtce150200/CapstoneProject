using BusinessObject.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Invoice : BaseEntity
    {
        public string Description { get; set; }
        public Prescription Prescription { get; set; }
    }
}
