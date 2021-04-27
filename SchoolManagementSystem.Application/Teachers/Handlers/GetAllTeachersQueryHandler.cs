using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Teachers.DTOs;
using SchoolManagementSystem.Application.Teachers.Queries;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Teachers.Handlers
{
    public class GetAllTeachersQueryHandler :
        IRequestHandlerWrapper<GetAllTeachersQuery, IList<TeacherDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTeachersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IList<TeacherDto>>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _context.Teachers.AsNoTracking()
                .ToListAsync(cancellationToken);

            if (teachers is null)
            {
                return Response.Fail<IList<TeacherDto>>("Problem occured while fetching data!");
            }

            var result = _mapper.Map<IList<TeacherDto>>(teachers);
            return Response.Success<IList<TeacherDto>>(result, "Teachers fetched successfully.");
        }
    }
}