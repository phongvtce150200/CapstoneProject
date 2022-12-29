using BusinessObject.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Qualification : BaseEntity
    {
        public string QualificationName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidThru { get; set; }
        public int? NurseId { get; set; }
        [ForeignKey("NurseId")]
        public Nurse Nurse { get; set; }
        public int? DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }
}
