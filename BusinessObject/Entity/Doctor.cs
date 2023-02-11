using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Doctor : BaseEntity
    {
        public int Experience { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<Queue> queues { get; set; }
        public ICollection<Appointment> appointments { get; set; }
        public ICollection<Qualification> qualifications { get; set; }
    }
}
