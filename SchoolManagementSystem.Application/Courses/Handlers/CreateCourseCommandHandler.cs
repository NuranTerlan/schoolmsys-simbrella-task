using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Courses.Commands;
using SchoolManagementSystem.Application.Courses.DTOs;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Courses.Handlers
{
    public class CreateCourseCommandHandler : 
        IRequestHandlerWrapper<CreateCourseCommand, CourseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<CourseDto>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var newCourse = _mapper.Map<Course>(request);

            await _context.Courses.AddAsync(newCourse, cancellationToken);
            var isAdded = await _context.SaveChangesAsync(cancellationToken);

            if (isAdded == 0)
            {
                return Response.Fail<CourseDto>("Couldn't add entity!");
            }

            var result = _mapper.Map<CourseDto>(newCourse);

            return Response.Success<CourseDto>(result, $"New course with ID#{result.Id} is successfully added to db");
        }
    }
}