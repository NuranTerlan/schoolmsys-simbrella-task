using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.SchoolClasses.Commands;
using SchoolManagementSystem.Application.SchoolClasses.DTOs;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.SchoolClasses.Handlers
{
    public class CreateSchoolClassCommandHandler :
        IRequestHandlerWrapper<CreateSchoolClassCommand, SchoolClassDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateSchoolClassCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<SchoolClassDto>> Handle(CreateSchoolClassCommand request, CancellationToken cancellationToken)
        {
            var psychologist = await _context.Psychologists.AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == request.PsychologistId,
                    cancellationToken);

            if (psychologist is null)
            {
                return Response.Fail<SchoolClassDto>($"Psychologist with ID#{request.PsychologistId} is not found!");
            }

            var newClass = _mapper.Map<SchoolClass>(request);
            await _context.SchoolClasses.AddAsync(newClass, cancellationToken);
            var isAdded = await _context.SaveChangesAsync(cancellationToken);
            if (isAdded == 0)
            {
                return Response.Fail<SchoolClassDto>("Couldn't add entity!");
            }

            var result = _mapper.Map<SchoolClassDto>(newClass);
            return Response.Success<SchoolClassDto>(result,
                $"New class with ID#{result.Id} is successfully added to db");
        }
    }
}