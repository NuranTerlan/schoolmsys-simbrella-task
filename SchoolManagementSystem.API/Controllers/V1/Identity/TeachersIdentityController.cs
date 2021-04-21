using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Contracts;
using SchoolManagementSystem.Application.Teachers.Commands;

namespace SchoolManagementSystem.API.Controllers.V1.Identity
{
    public class TeachersIdentityController : ApiController
    {
        [HttpPost(ApiRoutesV1.Identity.Teacher.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterTeacherCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost(ApiRoutesV1.Identity.Teacher.Login)]
        public async Task<IActionResult> Login([FromBody] LoginTeacherCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}