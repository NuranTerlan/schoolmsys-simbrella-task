using System;

namespace SchoolManagementSystem.Application.TeacherClasses.DTOs
{
    public class TeacherClassDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string TeacherId { get; set; }
        public int SchoolClassId { get; set; }
        public int CourseId { get; set; }
    }
}