using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Commons;

namespace SchoolManagementSystem.Domain.Entities
{
    public class SchoolClass : AuditEntity
    {
        [Required]
        [MaxLength(10)]
        public string Title { get; set; }
        [Required]
        [MaxLength(10)]
        public string RoomNumber { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TeacherClass> TeacherClasses { get; set; }
        public virtual string PsychologistId { get; set; }
        public virtual Psychologist Psychologist { get; set; }
    }
}