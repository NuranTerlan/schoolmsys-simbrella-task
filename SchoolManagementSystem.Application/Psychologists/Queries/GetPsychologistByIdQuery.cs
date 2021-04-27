using SchoolManagementSystem.Application.Psychologists.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Psychologists.Queries
{
    public class GetPsychologistByIdQuery : IRequestWrapper<PsychologistDto>
    {
        public string Id { get; set; }
    }
}