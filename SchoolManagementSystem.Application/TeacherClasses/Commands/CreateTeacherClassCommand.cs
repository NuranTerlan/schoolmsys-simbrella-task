using System;
using System.Collections.Generic;
using SchoolManagementSystem.Application.TeacherClasses.DTOs;
using SchoolManagementSystem.Application.Wrappers;

namespace SchoolManagementSystem.Application.TeacherClasses.Commands
{
    public class CreateTeacherClassCommand : IRequestWrapper<TeacherClassDto>
    {
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public int SchoolClassId { get; set; }
        public string TeacherEmail { get; set; }
        public int CourseId { get; set; }
    }
}