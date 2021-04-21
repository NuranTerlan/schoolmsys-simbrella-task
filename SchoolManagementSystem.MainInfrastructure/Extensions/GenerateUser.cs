using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Commons;
using SchoolManagementSystem.Domain.Enumerations;

namespace SchoolManagementSystem.MainInfrastructure.Extensions
{
    public static class GenerateUser
    {
        public static void SeedAdminUser(string username, string email,
            ModelBuilder builder)
        {
            const string userId = "8691d119-f241-474a-bf88-3941618e5caf";
            const string adminRoleId = "a1bb5179-59a8-471e-a29a-90065b471062";
            const string teacherRoleId = "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1";
            const string studentRoleId = "9cd957ee-1c33-494e-b153-cc9a4a4edead";

            var user = new ApplicationUser
            {
                Id = userId,
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                FirstName = "Nuran",
                LastName = "Terlan",
                Address = "Sumqayit",
                BirthYear = 2002,
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                ConcurrencyStamp = userId
            };

            var ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "admin123");

            var roles = new List<AppUserRole>
            {
                new AppUserRole
                {
                    Id = adminRoleId,
                    Name = Role.Admin.ToString(),
                    NormalizedName = Role.Admin.ToString().ToUpper(),
                    Description = "Admin can manage everything in app",
                    ConcurrencyStamp = adminRoleId
                },
                new AppUserRole
                {
                    Id = teacherRoleId,
                    Name = Role.Teacher.ToString(),
                    NormalizedName = Role.Teacher.ToString().ToUpper(),
                    Description = "Teacher can report, schedule exam dates, give marks etc.",
                    ConcurrencyStamp = teacherRoleId
                },
                new AppUserRole
                {
                    Id = studentRoleId,
                    Name = Role.Student.ToString(),
                    NormalizedName = Role.Student.ToString().ToUpper(),
                    Description = "Students can check their exam dates, marks etc.",
                    ConcurrencyStamp = studentRoleId
                }
            };

            builder.Entity<ApplicationUser>().HasData(user);
            foreach (var role in roles)
            {
                builder.Entity<AppUserRole>().HasData(role);
                builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        UserId = userId,
                        RoleId = role.Id
                    });
            }
        }

        //public static void SeedTeacherRole(ModelBuilder builder)
        //{
        //    const string teacherRoleId = "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1";

        //    var role = new AppUserRole
        //    {
        //        Id = teacherRoleId,
        //        Name = Role.Teacher.ToString(),
        //        NormalizedName = Role.Teacher.ToString().ToUpper(),
        //        Description = "Teacher can report, schedule exam dates, give marks etc.",
        //        ConcurrencyStamp = teacherRoleId
        //    };

        //    builder.Entity<AppUserRole>().HasData(role);
        //}

        //public static void SeedStudentRole(ModelBuilder builder)
        //{
        //    const string studentRoleId = "9cd957ee-1c33-494e-b153-cc9a4a4edead";

        //    var role = new AppUserRole
        //    {
        //        Id = studentRoleId,
        //        Name = Role.Student.ToString(),
        //        NormalizedName = Role.Student.ToString().ToUpper(),
        //        Description = "Students can check their exam dates, marks etc.",
        //        ConcurrencyStamp = studentRoleId
        //    };
        //    builder.Entity<AppUserRole>().HasData(role);
        //}
    }
}