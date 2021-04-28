using SchoolManagementSystem.Application.Students.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Students.Commands
{
    public class IncreaseStudentAbsentMarkCommand : IRequestWrapper<StudentDto>
    {
        public string StudentId { get; set; }
        public byte Count { get; set; }
    }
}