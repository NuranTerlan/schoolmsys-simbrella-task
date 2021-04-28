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
    public class UpdateSchoolClassCommandHandler :
        IRequestHandlerWrapper<UpdateSchoolClassCommand, SchoolClassDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateSchoolClassCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<SchoolClassDto>> Handle(UpdateSchoolClassCommand request, CancellationToken cancellationToken)
        {
            var schoolClass = await _context.SchoolClasses.AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (schoolClass is null)
            {
                return Response.Fail<SchoolClassDto>($"Class#{request.Id} isn't found or an error occured while fetching related data!");
            }

            var psychologist = await _context.Psychologists.AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == request.PsychologistId,
                    cancellationToken);

            if (psychologist is null)
            {
                return Response.Fail<SchoolClassDto>($"Psychologist with ID#{request.PsychologistId} is not found!");
            }

            var updatedClass = new SchoolClassDto
            {
                Id = schoolClass.Id,
                Title = request.Title,
                RoomNumber = request.RoomNumber,
                CreatedOn = schoolClass.CreatedOn,
                PsychologistId = request.PsychologistId
            };

            _context.SchoolClasses.Update(_mapper.Map<SchoolClass>(updatedClass));

            var isUpdated = await _context.SaveChangesAsync(cancellationToken);
            if (isUpdated == 0)
            {
                return Response.Fail<SchoolClassDto>($"Couldn't update class#{schoolClass.Id}!");
            }

            var result = await _context.SchoolClasses.AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            return Response.Success<SchoolClassDto>(_mapper.Map<SchoolClassDto>(result),
                $"Class#{schoolClass.Id} is updated successfully.");
        }
    }
}