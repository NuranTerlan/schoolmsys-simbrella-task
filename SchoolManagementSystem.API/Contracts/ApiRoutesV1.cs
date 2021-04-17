namespace SchoolManagementSystem.API.Contracts
{
    public class ApiRoutes : IRoutesHolder
    {
        public static string Root { get; set; }
        public static string Version { get; set; }
        public static string Base { get; } = Root + "/" + Version;

        public ApiRoutes(string root = "api", string version = "vx")
        {
            Root = root;
            Version = version;
        }
    }
}