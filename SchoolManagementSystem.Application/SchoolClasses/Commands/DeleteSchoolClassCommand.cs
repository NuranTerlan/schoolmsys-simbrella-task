using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.SchoolClasses.Commands
{
    public class DeleteSchoolClassCommand : IRequestWrapper<int>
    {
        public int Id { get; set; }
    }
}