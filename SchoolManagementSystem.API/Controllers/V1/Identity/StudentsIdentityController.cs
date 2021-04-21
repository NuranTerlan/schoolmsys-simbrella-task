using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Contracts;
using SchoolManagementSystem.Application.Students.Commands;

namespace SchoolManagementSystem.API.Controllers.V1.Identity
{
    public class StudentsIdentityController : ApiController
    {
        [HttpPost(ApiRoutesV1.Identity.Student.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterStudentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost(ApiRoutesV1.Identity.Student.Login)]
        public async Task<IActionResult> Login([FromBody] LoginStudentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}