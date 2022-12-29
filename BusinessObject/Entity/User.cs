using Microsoft.AspNetCore.Identity;
using System;

namespace BusinessObject.Entity
{
    public class User : IdentityUser
    {
        public string Image { get; set; } = "https://media.istockphoto.com/id/476085198/photo/businessman-silhouette-as-avatar-or-default-profile-picture.jpg?s=612x612&w=0&k=20&c=GVYAgYvyLb082gop8rg0XC_wNsu0qupfSLtO7q9wu38=";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
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
    public enum Gender
    {
        Male = 1,
        Female = 0
    }

}
