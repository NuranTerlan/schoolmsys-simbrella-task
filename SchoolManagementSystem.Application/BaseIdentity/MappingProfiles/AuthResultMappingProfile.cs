using AutoMapper;
using SchoolManagementSystem.Application.BaseIdentity.DTOs;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.BaseIdentity.MappingProfiles
{
    public class AuthResultMappingProfile : Profile
    {
        public AuthResultMappingProfile()
        {
            CreateMap<AuthenticationResult, AuthResultDto>().ReverseMap();
        }
    }
}