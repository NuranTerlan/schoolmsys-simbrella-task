using AutoMapper;
using SchoolManagementSystem.Application.Students.Commands;
using SchoolManagementSystem.Application.Students.DTOs;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Students.MappingProfiles
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<RegisterStudentCommand, Student>();
            CreateMap<ApplicationUser, Student>();
            CreateMap<StudentDto, Student>().ReverseMap();
        }
    }
}