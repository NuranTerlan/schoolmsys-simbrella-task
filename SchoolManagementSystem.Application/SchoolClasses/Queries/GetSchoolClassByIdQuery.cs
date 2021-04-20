using SchoolManagementSystem.Application.SchoolClasses.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.SchoolClasses.Queries
{
    public class GetSchoolClassByIdQuery : IRequestWrapper<SchoolClassDto>
    {
        public int Id { get; set; }
    }
}