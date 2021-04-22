using System.Collections.Generic;
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
    public class GetAllStudentsQueryHandler : 
        IRequestHandlerWrapper<GetAllStudentsQuery, IList<StudentDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IList<StudentDto>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Students.AsNoTracking()
                .ToListAsync(cancellationToken);
            if (students is null)
            {
                return Response.Fail<IList<StudentDto>>("Problem occured while fetching data!");
            }

            var result = _mapper.Map<IList<StudentDto>>(students);
            return Response.Success(result, "Students fetched successfully.");
        }
    }
}