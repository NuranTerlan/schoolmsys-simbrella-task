using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Commons;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Student : ApplicationUser
    {
        public byte AveragePerformanceForYear { get; set; }

        [Required]
        public int? SchoolClassId { get; set; }
        public virtual SchoolClass SchoolClass { get; set; }
    }
}