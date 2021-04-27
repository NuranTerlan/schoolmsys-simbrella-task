using System;
using System.Collections;
using System.Collections.Generic;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.SchoolClasses.DTOs
{
    public class SchoolClassDto
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string Title { get; set; }
        public string RoomNumber { get; set; }
        public ICollection<Student> Students { get; set; }
        public string PsychologistId { get; set; }
    }
}