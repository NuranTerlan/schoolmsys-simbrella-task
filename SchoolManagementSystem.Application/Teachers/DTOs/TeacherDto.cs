using System.Collections;
using System.Collections.Generic;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Teachers.DTOs
{
    public class TeacherDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}