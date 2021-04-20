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
    }
}