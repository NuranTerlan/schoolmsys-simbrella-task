namespace SchoolManagementSystem.API.Contracts
{
    public static class ApiRoutesV1
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Courses
        {
            public const string GetAll = Base + "/courses";
            public const string GetById = GetAll + "/{courseId}";
            public const string Create = Base + "/courses";
            public const string Update = GetAll + "/{courseId}";
            public const string Delete = GetAll + "/{courseId}";
        }

        public static class SchoolClasses
        {
            public const string GetAll = Base + "/classes";
            public const string GetById = GetAll + "/{classId}";
            public const string Create = Base + "/classes";
            public const string Update = GetAll + "/{classId}";
            public const string Delete = GetAll + "/{classId}";
        }

        public static class Identity
        {
            public const string IdentityBase = Base + "/identity";

            public static class Student
            {
                public const string StudentSpecificBase = IdentityBase + "/student";

                public const string Login = StudentSpecificBase + "/login";
                public const string Register = StudentSpecificBase + "/register";
            }

            public static class Teacher
            {
                public const string TeacherSpecificBase = IdentityBase + "/teacher";

                public const string Login = TeacherSpecificBase + "/login";
                public const string Register = TeacherSpecificBase + "/register";
            }
        }

        public static class Students
        {
            public const string GetAll = Base + "/students";
            public const string GetById = GetAll + "/{studentId}";
            public const string Create = Base + "/students";
            public const string Update = GetAll + "/{studentId}";
            public const string Delete = GetAll + "/{studentId}";
        }

        public static class Teachers
        {
            public const string GetAll = Base + "/teachers";
            public const string GetById = GetAll + "/{teacherId}";
            public const string Create = Base + "/teachers";
            public const string Update = GetAll + "/{teacherId}";
            public const string Delete = GetAll + "/{teacherId}";
        }

        public static class TeacherClasses
        {
            public const string GetAll = Base + "/teacherclasses";
            public const string Create = Base + "/teacherclasses";
        }
    }
}