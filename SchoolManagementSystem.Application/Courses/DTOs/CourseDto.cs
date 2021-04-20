using System;

namespace SchoolManagementSystem.Application.Courses.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}