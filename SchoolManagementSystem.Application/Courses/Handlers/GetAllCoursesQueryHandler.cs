using System.Collections.Generic;
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
    public class GetAllCoursesQueryHandler :
        IRequestHandlerWrapper<GetAllCoursesQuery, IList<CourseDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCoursesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IList<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _context.Courses.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            if (courses is null)
            {
                return Response.Fail<IList<CourseDto>>("An error occured while fetching data!");
            }

            var result = _mapper.Map<List<CourseDto>>(courses);
            return Response.Success<IList<CourseDto>>(result, "Courses are fetched successfully.");
        }
    }
}