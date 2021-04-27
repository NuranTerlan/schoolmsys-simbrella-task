using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Psychologists.DTOs;
using SchoolManagementSystem.Application.Psychologists.Queries;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.Psychologists.Handlers
{
    public class GetAllPsychologistsQueryHandler :
        IRequestHandlerWrapper<GetAllPsychologistsQuery, IList<PsychologistDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPsychologistsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IList<PsychologistDto>>> Handle(GetAllPsychologistsQuery request, CancellationToken cancellationToken)
        {
            var psychologists = await _context.Psychologists.AsNoTracking()
                .ToListAsync(cancellationToken);

            if (psychologists is null)
            {
                return Response.Fail<IList<PsychologistDto>>("Problem occured while fetching data!");
            }

            var result = _mapper.Map<IList<PsychologistDto>>(psychologists);
            return Response.Success<IList<PsychologistDto>>(result, "Psychologists are fetched successfully.");
        }
    }
}