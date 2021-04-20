using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Courses.DTOs;
using SchoolManagementSystem.Application.Courses.Queries;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Courses.Handlers
{
    public class GetCourseByIdQueryHandler :
        IRequestHandlerWrapper<GetCourseByIdQuery, CourseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCourseByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses.AsNoTracking().SingleOrDefaultAsync(
                c => c.Id == request.Id, cancellationToken);

            if (course is null)
            {
                return Response.Fail<CourseDto>($"Course#{request.Id} isn't found or an error occured while fetching data!");
            }

            var result = _mapper.Map<CourseDto>(course);
            return Response.Success<CourseDto>(result, $"Course#{request.Id} is fetched successfully");
        }
    }
}