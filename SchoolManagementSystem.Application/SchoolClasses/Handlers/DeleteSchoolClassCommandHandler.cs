using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.SchoolClasses.Commands;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.SchoolClasses.Handlers
{
    public class DeleteSchoolClassCommandHandler :
        IRequestHandlerWrapper<DeleteSchoolClassCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSchoolClassCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<int>> Handle(DeleteSchoolClassCommand request, CancellationToken cancellationToken)
        {
            var schoolClass = await _context.SchoolClasses.AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (schoolClass is null)
            {
                return Response.Fail<int>($"Class#{request.Id} isn't found or an error occured while fetching related data!");
            }

            _context.SchoolClasses.Remove(schoolClass);
            var isRemoved = await _context.SaveChangesAsync(cancellationToken);
            if (isRemoved == 0)
            {
                return Response.Fail<int>($"Couldn't delete class#{schoolClass.Id}!");
            }

            return Response.Success<int>(schoolClass.Id, $"Class#{schoolClass.Id} is deleted successfully.");
        }
    }
}