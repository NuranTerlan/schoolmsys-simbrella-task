using AutoMapper;
using SchoolManagementSystem.Application.Teachers.Commands;
using SchoolManagementSystem.Application.Teachers.DTOs;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Teachers.MappingProfiles
{
    public class TeacherMappingProfile : Profile
    {
        public TeacherMappingProfile()
        {
            CreateMap<RegisterTeacherCommand, Teacher>();
            CreateMap<ApplicationUser, Teacher>();
            CreateMap<TeacherDto, Teacher>().ReverseMap();
        }
    }
}