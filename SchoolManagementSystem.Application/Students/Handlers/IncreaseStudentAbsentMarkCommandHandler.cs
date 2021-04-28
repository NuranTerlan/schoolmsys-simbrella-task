using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Students.Commands;
using SchoolManagementSystem.Application.Students.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Students.Handlers
{
    public class IncreaseStudentAbsentMarkCommandHandler :
        IRequestHandlerWrapper<IncreaseStudentAbsentMarkCommand, StudentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IncreaseStudentAbsentMarkCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<StudentDto>> Handle(IncreaseStudentAbsentMarkCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == request.StudentId,
                    cancellationToken);

            if (student is null)
            {
                return Response.Fail<StudentDto>($"Student with ID#{request.StudentId} doesn't exist!");
            }

            student.AbsentMarkCount += request.Count;
            var result = _mapper.Map<StudentDto>(student);
            return Response.Success<StudentDto>(result,
                $"{request.Count} absent mark is added for student ID#{request.StudentId} context");
        }
    }
}