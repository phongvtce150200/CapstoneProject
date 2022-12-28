using BusinessObject.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Queue : BaseEntity
    {
        public int Pulse { get; set; }
        public int BloodPressure { get; set; }
        public int Tempurature { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }   
        public ICollection<Doctor> doctors { get; set; }  
        public ICollection<Patient> patients { get; set; }  
    }
}
