﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagementSystem.MainInfrastructure.Data;

namespace SchoolManagementSystem.MainInfrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210428195457_Student-Table-Updated")]
    partial class StudentTableUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "8691d119-f241-474a-bf88-3941618e5caf",
                            RoleId = "a1bb5179-59a8-471e-a29a-90065b471062"
                        },
                        new
                        {
                            UserId = "8691d119-f241-474a-bf88-3941618e5caf",
                            RoleId = "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1"
                        },
                        new
                        {
                            UserId = "8691d119-f241-474a-bf88-3941618e5caf",
                            RoleId = "9cd957ee-1c33-494e-b153-cc9a4a4edead"
                        },
                        new
                        {
                            UserId = "8691d119-f241-474a-bf88-3941618e5caf",
                            RoleId = "2403f407-e7bf-4c60-ade2-fc36f26afc55"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Commons.AppUserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "a1bb5179-59a8-471e-a29a-90065b471062",
                            ConcurrencyStamp = "a1bb5179-59a8-471e-a29a-90065b471062",
                            Description = "Admin can manage everything in app",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1",
                            ConcurrencyStamp = "bcf2deb6-1dc6-4dfd-a8be-573f3f998af1",
                            Description = "Teacher can report, schedule exam dates, give marks etc.",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = "9cd957ee-1c33-494e-b153-cc9a4a4edead",
                            ConcurrencyStamp = "9cd957ee-1c33-494e-b153-cc9a4a4edead",
                            Description = "Students can check their exam dates, marks etc.",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = "2403f407-e7bf-4c60-ade2-fc36f26afc55",
                            ConcurrencyStamp = "2403f407-e7bf-4c60-ade2-fc36f26afc55",
                            Description = "Psychologists can give motivation to students",
                            Name = "Psychologist",
                            NormalizedName = "PSYCHOLOGIST"
                        });
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Commons.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("BirthYear")
                        .HasColumnType("smallint");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "8691d119-f241-474a-bf88-3941618e5caf",
                            AccessFailedCount = 0,
                            Address = "Sumqayit",
                            BirthYear = (short)2002,
                            ConcurrencyStamp = "8691d119-f241-474a-bf88-3941618e5caf",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "devvhale@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Nuran",
                            Gender = 0,
                            LastName = "Terlan",
                            LockoutEnabled = false,
                            NormalizedEmail = "DEVVHALE@GMAIL.COM",
                            NormalizedUserName = "DEVVHALE",
                            PasswordHash = "AQAAAAEAACcQAAAAEJNXj0Wc59LBvbk0iizILONUXY2JaudYeBmzQT8jxQNPWTy5Hnn1PiNWr5yMavSVjQ==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "ae868f51-56c3-45ff-86aa-24ed488cc9a0",
                            TwoFactorEnabled = true,
                            UserName = "devvhale"
                        });
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.SchoolClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PsychologistId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("PsychologistId");

                    b.ToTable("SchoolClasses");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.TeacherClass", b =>
                {
                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SchoolClassId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("From")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("To")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("TeacherId", "SchoolClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("SchoolClassId");

                    b.ToTable("TeacherClasses");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Psychologist", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Domain.Commons.ApplicationUser");

                    b.Property<string>("IndividualRoom")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.ToTable("Psychologists");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Student", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Domain.Commons.ApplicationUser");

                    b.Property<short>("AbsentMarkCount")
                        .HasColumnType("smallint");

                    b.Property<byte>("AveragePerformanceForYear")
                        .HasColumnType("tinyint");

                    b.Property<int?>("SchoolClassId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasIndex("SchoolClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Teacher", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Domain.Commons.ApplicationUser");

                    b.Property<string>("AboutMe")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("AcademicDegree")
                        .HasColumnType("int");

                    b.Property<byte>("CountOfExperienceYears")
                        .HasColumnType("tinyint");

                    b.Property<string>("IndividualRoom")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Commons.AppUserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Commons.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Commons.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Commons.AppUserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Domain.Commons.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Commons.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.SchoolClass", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Entities.Psychologist", "Psychologist")
                        .WithMany("SchoolClasses")
                        .HasForeignKey("PsychologistId");

                    b.Navigation("Psychologist");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.TeacherClass", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Entities.Course", "Course")
                        .WithMany("TeacherClasses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Domain.Entities.SchoolClass", "SchoolClass")
                        .WithMany("TeacherClasses")
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Domain.Entities.Teacher", "Teacher")
                        .WithMany("TeacherClasses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("SchoolClass");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Psychologist", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Commons.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Domain.Entities.Psychologist", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Student", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Commons.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Domain.Entities.Student", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Domain.Entities.SchoolClass", "SchoolClass")
                        .WithMany("Students")
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SchoolClass");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Teacher", b =>
                {
                    b.HasOne("SchoolManagementSystem.Domain.Commons.ApplicationUser", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Domain.Entities.Teacher", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Course", b =>
                {
                    b.Navigation("TeacherClasses");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.SchoolClass", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("TeacherClasses");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Psychologist", b =>
                {
                    b.Navigation("SchoolClasses");
                });

            modelBuilder.Entity("SchoolManagementSystem.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("TeacherClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
