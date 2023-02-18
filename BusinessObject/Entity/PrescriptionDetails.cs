using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class PrescriptionDetails
    {
        [Key]
        public int PrescriptionId { get; set; }
        [ForeignKey("PrescriptionId")]
        public Prescription Prescription { get; set; }
        [Key]
        public int MedicineId { get; set; }
        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }  
        public int MedicineAmount { get; set; }
        public string UsingDay { get; set; }
        public string TimesPerDay { get; set; }
        public string UsingType { get; set; }
        public Session Session { get; set; }
        public string Description { get; set; }

    }
    public enum Session
    {
        Morning = 1,
        Noon = 2,
        Afternoon = 3,
    }
}
