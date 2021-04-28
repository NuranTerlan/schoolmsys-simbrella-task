using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.MainInfrastructure.Extensions;

namespace SchoolManagementSystem.MainInfrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
            AppUserRole, string>,
        IApplicationDbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Psychologist> Psychologists { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entityEntry in ChangeTracker.Entries<IAuditInfo>())
            {
                switch (entityEntry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entityEntry.Entity.LastModifiedOn = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entityEntry.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted).ToList();
            foreach (var entityEntry in changedEntriesCopy)
            {
                entityEntry.State = EntityState.Detached;
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            GenerateUser.SeedAdminUser("devvhale", 
                "devvhale@gmail.com", modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<AppUserRole>().ToTable("Roles");

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Psychologist>().ToTable("Psychologists");

            modelBuilder.Entity<Student>()
                .HasOne(s => s.SchoolClass)
                .WithMany(sc => sc.Students)
                .HasForeignKey(s => s.SchoolClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SchoolClass>()
                .HasOne(c => c.Psychologist)
                .WithMany(p => p.SchoolClasses)
                .HasForeignKey(c => c.PsychologistId);

            modelBuilder.Entity<TeacherClass>()
                .HasKey(tc => new {tc.TeacherId, tc.SchoolClassId});
            modelBuilder.Entity<TeacherClass>()
                .HasOne(tc => tc.Teacher)
                .WithMany(t => t.TeacherClasses)
                .HasForeignKey(tc => tc.TeacherId);
            modelBuilder.Entity<TeacherClass>()
                .HasOne(tc => tc.SchoolClass)
                .WithMany(sc => sc.TeacherClasses)
                .HasForeignKey(tc => tc.SchoolClassId);
            modelBuilder.Entity<TeacherClass>()
                .HasOne(tc => tc.Course)
                .WithMany(c => c.TeacherClasses)
                .HasForeignKey(tc => tc.CourseId);
        }
    }
}
