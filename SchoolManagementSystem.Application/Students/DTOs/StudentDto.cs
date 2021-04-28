namespace SchoolManagementSystem.Application.Students.DTOs
{
    public class StudentDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public short AbsentMarkCount { get; set; }
        public string SchoolClassId { get; set; }
    }
}