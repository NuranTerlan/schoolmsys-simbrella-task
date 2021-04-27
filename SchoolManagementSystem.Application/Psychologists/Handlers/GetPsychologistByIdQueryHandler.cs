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
    public class GetPsychologistByIdQueryHandler :
        IRequestHandlerWrapper<GetPsychologistByIdQuery, PsychologistDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPsychologistByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<PsychologistDto>> Handle(GetPsychologistByIdQuery request, CancellationToken cancellationToken)
        {
            var psychologist = await _context.Psychologists.AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (psychologist is null)
            {
                return Response.Fail<PsychologistDto>($"Psychologist is not found with ID#{request.Id}");
            }

            var result = _mapper.Map<PsychologistDto>(psychologist);
            return Response.Success<PsychologistDto>(result, $"Psychologist with {request.Id} ID is fetched");
        }
    }
}