using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.TeacherClasses.DTOs;
using SchoolManagementSystem.Application.TeacherClasses.Queries;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.TeacherClasses.Handlers
{
    public class GetAllTeacherClassesQueryHandler :
        IRequestHandlerWrapper<GetAllTeacherClassesQuery, IList<TeacherClassDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTeacherClassesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IList<TeacherClassDto>>> Handle(GetAllTeacherClassesQuery request, CancellationToken cancellationToken)
        {
            var teacherClasses = await _context.TeacherClasses.AsNoTracking()
                .ToListAsync(cancellationToken);
            if (teacherClasses is null)
            {
                return Response.Fail<IList<TeacherClassDto>>("An error occured while fetching data!");
            }

            var result = _mapper.Map<List<TeacherClassDto>>(teacherClasses);
            return Response.Success<IList<TeacherClassDto>>(result, "TeacherClass relationships are fetched successfully.");
        }
    }
}