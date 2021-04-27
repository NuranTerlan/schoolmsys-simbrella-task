using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Contracts;
using SchoolManagementSystem.Application.Psychologists.Commands;

namespace SchoolManagementSystem.API.Controllers.V1.Identity
{
    public class PsychologistsIdentityController : ApiController
    {
        [HttpPost(ApiRoutesV1.Identity.Psychologist.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterPsychologistCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost(ApiRoutesV1.Identity.Psychologist.Login)]
        public async Task<IActionResult> Login([FromBody] LoginPsychologistCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}