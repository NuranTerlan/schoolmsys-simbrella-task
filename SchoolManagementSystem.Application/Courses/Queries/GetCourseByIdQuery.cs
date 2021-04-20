using SchoolManagementSystem.Application.Courses.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Courses.Queries
{
    public class GetCourseByIdQuery : IRequestWrapper<CourseDto>
    {
        public int Id { get; set; }
    }
}