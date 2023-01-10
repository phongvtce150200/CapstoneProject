using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;  
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
