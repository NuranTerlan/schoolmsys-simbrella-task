using SchoolManagementSystem.Application.Students.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Students.Queries
{
    public class GetStudentByIdQuery : IRequestWrapper<StudentDto>
    {
        public string Id { get; set; }
    }
}