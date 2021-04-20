using SchoolManagementSystem.Application.Courses.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Courses.Commands
{
    public class UpdateCourseCommand : IRequestWrapper<CourseDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}