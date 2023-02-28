using BusinessObject.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Entity
{
    public class Patient
    {
        [Key]
        public int? Id { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<Queue> queues { get; set; }
    }
}
