using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class TeacherClass
    {
        [Required]
        public DateTime? From { get; set; }
        [Required]
        public DateTime? To { get; set; }

        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}