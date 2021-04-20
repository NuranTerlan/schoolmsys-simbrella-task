using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Courses.Commands;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Courses.Handlers
{
    public class DeleteCourseCommandHandler :
        IRequestHandlerWrapper<DeleteCourseCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCourseCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<int>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses.AsNoTracking().SingleOrDefaultAsync(
                c => c.Id == request.Id, cancellationToken);

            if (course is null)
            {
                return Response.Fail<int>($"Course#{request.Id} isn't found or an error occured while fetching related data!");
            }

            _context.Courses.Remove(course);
            var isRemoved = await _context.SaveChangesAsync(cancellationToken);
            if (isRemoved == 0)
            {
                return Response.Fail<int>($"Couldn't delete course#{course.Id}!");
            }

            return Response.Success<int>(course.Id, $"Course#{course.Id} is deleted successfully.");
        }
    }
}