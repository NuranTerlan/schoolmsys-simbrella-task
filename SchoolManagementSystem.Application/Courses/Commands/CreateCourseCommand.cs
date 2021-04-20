using System;
using SchoolManagementSystem.Application.Courses.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Courses.Commands
{
    public class CreateCourseCommand : IRequestWrapper<CourseDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}