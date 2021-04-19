using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Enumerations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Teacher : ApplicationUser
    {
        [MaxLength(2000)]
        public string AboutMe { get; set; }
        [Required]
        [MaxLength(5)]
        public string IndividualRoom { get; set; }
        public byte CountOfExperienceYears { get; set; }
        public AcademicDegree AcademicDegree { get; set; }

        public virtual ICollection<TeacherClass> TeacherClasses { get; set; }
    }
}