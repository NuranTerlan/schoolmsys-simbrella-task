using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Courses.Commands
{
    public class DeleteCourseCommand : IRequestWrapper<int>
    {
        public int Id { get; set; }
    }
}