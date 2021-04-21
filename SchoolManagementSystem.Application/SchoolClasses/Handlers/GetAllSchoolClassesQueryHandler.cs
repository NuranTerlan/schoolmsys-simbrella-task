using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.SchoolClasses.DTOs;
using SchoolManagementSystem.Application.SchoolClasses.Queries;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.SchoolClasses.Handlers
{
    public class GetAllSchoolClassesQueryHandler :
        IRequestHandlerWrapper<GetAllSchoolClassesQuery, IList<SchoolClassDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllSchoolClassesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IList<SchoolClassDto>>> Handle(GetAllSchoolClassesQuery request, CancellationToken cancellationToken)
        {
            var classes = await _context.SchoolClasses.AsNoTracking().Include(c => c.Students).ToListAsync(cancellationToken: cancellationToken);
            if (classes is null)
            {
                return Response.Fail<IList<SchoolClassDto>>("An error occured while fetching data!");
            }

            var result = _mapper.Map<IList<SchoolClassDto>>(classes);
            return Response.Success<IList<SchoolClassDto>>(result, "Classes are fetched successfully.");
        }
    }
}