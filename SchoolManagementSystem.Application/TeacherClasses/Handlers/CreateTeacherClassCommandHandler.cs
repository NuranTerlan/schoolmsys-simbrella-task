using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.TeacherClasses.Commands;
using SchoolManagementSystem.Application.TeacherClasses.DTOs;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.TeacherClasses.Handlers
{
    public class CreateTeacherClassCommandHandler :
        IRequestHandlerWrapper<CreateTeacherClassCommand, TeacherClassDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateTeacherClassCommandHandler(IApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response<TeacherClassDto>> Handle(CreateTeacherClassCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.TeacherEmail);
            if (user is null)
            {
                return Response.Fail<TeacherClassDto>($"Teacher with {request.TeacherEmail} email doesn't exist!");
            }

            var teacher = await _context.Teachers.AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == user.Id, cancellationToken);
            if (teacher is null)
            {
                return Response.Fail<TeacherClassDto>($"Teacher with {request.TeacherEmail} email doesn't exist!");
            }

            var schoolClass = await _context.SchoolClasses.AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == request.SchoolClassId, cancellationToken);
            if (schoolClass is null)
            {
                return Response.Fail<TeacherClassDto>($"Class with {request.SchoolClassId} ID doesn't exist!");
            }

            var course = await _context.Courses.AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == request.CourseId, cancellationToken);
            if (course is null)
            {
                return Response.Fail<TeacherClassDto>($"Course with {request.CourseId} ID doesn't exist!");
            }

            var teacherClass = _mapper.Map<TeacherClass>(request);
            teacherClass.TeacherId = teacher.Id;

            await _context.TeacherClasses.AddAsync(teacherClass,
                cancellationToken);

            var isAdded = await _context.SaveChangesAsync(cancellationToken);

            if (isAdded == 0)
            {
                return Response.Fail<TeacherClassDto>($"Can't add this relationship to the db!");
            }

            return Response.Success<TeacherClassDto>(_mapper.Map<TeacherClassDto>(teacherClass),
                "Success! Relation is prepared successfully.");
        }
    }
}