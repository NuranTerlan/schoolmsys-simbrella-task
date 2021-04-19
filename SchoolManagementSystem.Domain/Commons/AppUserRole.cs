using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Domain.Commons
{
    public class AppUserRole : IdentityRole
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}