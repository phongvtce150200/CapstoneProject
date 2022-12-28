using BusinessObject.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace BusinessObject.Entity
{
    public class Patient : BaseEntity
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? QueueId { get; set; }
        [ForeignKey("QueueId")]
        public Queue Queue { get; set; }
        public ICollection<Prescription> prescriptions { get; set; }
    }
}
