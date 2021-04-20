using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Application.Commons.Interfaces;

namespace SchoolManagementSystem.API.Services
{
    public class CurrentUserService : ICurrentUser
    {
        public string UserId { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User
                .FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}