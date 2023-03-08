using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Base;

namespace BusinessObject.Entity
{
    public class MLExpert : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int? Experience { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
