using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Courses.Commands;
using SchoolManagementSystem.Application.Courses.DTOs;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Courses.Handlers
{
    public class UpdateCourseCommandHandler :
        IRequestHandlerWrapper<UpdateCourseCommand, CourseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<CourseDto>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses.AsNoTracking().SingleOrDefaultAsync(
                c => c.Id == request.Id, cancellationToken);

            if (course is null)
            {
                return Response.Fail<CourseDto>($"Course#{request.Id} isn't found or an error occured while fetching related data!");
            }

            var updatedCourse = new CourseDto
            {
                Id = course.Id,
                Title = request.Title,
                Description = request.Description,
                CreatedOn = course.CreatedOn
            };

            _context.Courses.Update(_mapper.Map<Course>(updatedCourse));

            var isUpdated = await _context.SaveChangesAsync(cancellationToken);
            if (isUpdated == 0)
            {
                return Response.Fail<CourseDto>($"Couldn't update course#{course.Id}!");
            }

            var result = await _context.Courses.AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            return Response.Success<CourseDto>(_mapper.Map<CourseDto>(result), 
                $"Course#{course.Id} is updated successfully.");
        }
    }
}