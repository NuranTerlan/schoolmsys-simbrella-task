using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Students.DTOs;
using SchoolManagementSystem.Application.Students.Queries;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Students.Handlers
{
    public class GetStudentByIdQueryHandler :
        IRequestHandlerWrapper<GetStudentByIdQuery, StudentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
            if (student is null)
            {
                return Response.Fail<StudentDto>($"Student is not found with ID#{request.Id}");
            }

            var result = _mapper.Map<StudentDto>(student);
            return Response.Success<StudentDto>(result, $"Student with {request.Id} ID is fetched");
        }
    }
}