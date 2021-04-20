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
    public class GetSchoolClassByIdQueryHandler :
        IRequestHandlerWrapper<GetSchoolClassByIdQuery, SchoolClassDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSchoolClassByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<SchoolClassDto>> Handle(GetSchoolClassByIdQuery request, CancellationToken cancellationToken)
        {
            var schoolClass = await _context.SchoolClasses.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (schoolClass is null)
            {
                return Response.Fail<SchoolClassDto>($"Class#{request.Id} isn't found or an error occured while fetching data!");
            }

            var result = _mapper.Map<SchoolClassDto>(schoolClass);
            return Response.Success<SchoolClassDto>(result, $"Class#{request.Id} is fetched successfully");
        }
    }
}