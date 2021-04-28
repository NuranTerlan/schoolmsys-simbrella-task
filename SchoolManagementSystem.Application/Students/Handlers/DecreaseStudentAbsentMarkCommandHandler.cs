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
    public class DecreaseStudentAbsentMarkCommandHandler :
        IRequestHandlerWrapper<DecreaseStudentAbsentMarkCommand, StudentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DecreaseStudentAbsentMarkCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<StudentDto>> Handle(DecreaseStudentAbsentMarkCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == request.StudentId,
                    cancellationToken);

            if (student is null)
            {
                return Response.Fail<StudentDto>($"Student with ID#{request.StudentId} doesn't exist!");
            }

            if (student.AbsentMarkCount - request.Count < 0)
            {
                return Response.Fail<StudentDto>("Absent mark can not be negative value!");
            }

            student.AbsentMarkCount -= request.Count;
            var result = _mapper.Map<StudentDto>(student);
            return Response.Success<StudentDto>(result,
                $"{request.Count} absent mark is deleted from student ID#{request.StudentId} context");
        }
    }
}