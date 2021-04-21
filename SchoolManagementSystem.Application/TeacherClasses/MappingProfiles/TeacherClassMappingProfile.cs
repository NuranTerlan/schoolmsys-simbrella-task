using AutoMapper;
using SchoolManagementSystem.Application.TeacherClasses.Commands;
using SchoolManagementSystem.Application.TeacherClasses.DTOs;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.TeacherClasses.MappingProfiles
{
    public class TeacherClassMappingProfile : Profile
    {
        public TeacherClassMappingProfile()
        {
            CreateMap<CreateTeacherClassCommand, TeacherClass>();
            CreateMap<TeacherClass, TeacherClassDto>().ReverseMap();
        }
    }
}