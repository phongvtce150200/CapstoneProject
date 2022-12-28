using Microsoft.AspNetCore.Identity;
using System;

namespace BusinessObject.Entity
{
    public class User : IdentityUser
    {
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public DateTime BirthDay { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Doctor Doctor { get; set; }
        public Nurse Nurse { get; set; }
        public Patient Patient { get; set; }
    }
}
