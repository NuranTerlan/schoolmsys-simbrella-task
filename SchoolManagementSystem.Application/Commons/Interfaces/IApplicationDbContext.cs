using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Commons.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<SchoolClass> SchoolClasses { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<TeacherClass> TeacherClasses { get; set; }
        void DetachAllEntities();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}