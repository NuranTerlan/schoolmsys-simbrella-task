using SchoolManagementSystem.Application.SchoolClasses.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.SchoolClasses.Commands
{
    public class CreateSchoolClassCommand : IRequestWrapper<SchoolClassDto>
    {
        public string Title { get; set; }
        public string RoomNumber { get; set; }
        public string PsychologistId { get; set; }
    }
}