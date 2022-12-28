using BusinessObject.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Entity
{
    public class Nurse : BaseEntity
    {
        public string Qualification { get; set; }
        public int Experience { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
