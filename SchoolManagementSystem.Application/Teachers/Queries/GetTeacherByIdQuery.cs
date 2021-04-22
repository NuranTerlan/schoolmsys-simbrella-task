using SchoolManagementSystem.Application.Teachers.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Teachers.Queries
{
    public class GetTeacherByIdQuery : IRequestWrapper<TeacherDto>
    {
        public string Id { get; set; }
    }
}