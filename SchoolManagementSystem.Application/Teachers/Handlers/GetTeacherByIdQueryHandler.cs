using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Teachers.DTOs;
using SchoolManagementSystem.Application.Teachers.Queries;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Teachers.Handlers
{
    public class GetTeacherByIdQueryHandler :
        IRequestHandlerWrapper<GetTeacherByIdQuery, TeacherDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTeacherByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<TeacherDto>> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _context.Teachers
                .Include(t => t.TeacherClasses)
                .ThenInclude(tc => tc.SchoolClassId)
                .Include(t => t.TeacherClasses)
                .ThenInclude(tc => tc.CourseId)
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if (teacher is null)
            {
                return Response.Fail<TeacherDto>($"Teacher is not found with ID#{request.Id}");
            }

            var result = _mapper.Map<TeacherDto>(teacher);
            return Response.Success<TeacherDto>(result, $"Teacher with {request.Id} ID is fetched");
        }
    }
}