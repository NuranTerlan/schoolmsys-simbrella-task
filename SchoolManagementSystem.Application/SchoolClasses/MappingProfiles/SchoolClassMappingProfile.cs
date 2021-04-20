using AutoMapper;
using SchoolManagementSystem.Application.SchoolClasses.Commands;
using SchoolManagementSystem.Application.SchoolClasses.DTOs;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.SchoolClasses.MappingProfiles
{
    public class SchoolClassMappingProfile : Profile
    {
        public SchoolClassMappingProfile()
        {
            CreateMap<SchoolClass, SchoolClassDto>().ReverseMap();
            CreateMap<CreateSchoolClassCommand, SchoolClass>();
        }
    }
}