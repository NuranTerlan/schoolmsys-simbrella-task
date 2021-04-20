using AutoMapper;
using SchoolManagementSystem.Application.Courses.Commands;
using SchoolManagementSystem.Application.Courses.DTOs;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Courses.MappingProfiles
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<CreateCourseCommand, Course>();
        }
    }
}