using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Domain.Enumerations;

namespace SchoolManagementSystem.Domain.Commons
{
    public class ApplicationUser : IdentityUser, IAuditInfo
    {
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        public short BirthYear { get; set; }
        [Required]
        public string Address { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}