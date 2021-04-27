using AutoMapper;
using SchoolManagementSystem.Application.Psychologists.Commands;
using SchoolManagementSystem.Application.Psychologists.DTOs;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Psychologists.MappingProfiles
{
    public class PsychologistMappingProfile : Profile
    {
        public PsychologistMappingProfile()
        {
            CreateMap<RegisterPsychologistCommand, Psychologist>();
            CreateMap<ApplicationUser, Psychologist>();
            CreateMap<PsychologistDto, Psychologist>().ReverseMap();
        }
    }
}