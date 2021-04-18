using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Commons;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Course : AuditEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<TeacherClass> TeacherClasses { get; set; }
    }
}