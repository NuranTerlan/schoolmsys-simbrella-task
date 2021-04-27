using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Contracts;
using SchoolManagementSystem.Application.Psychologists.Queries;
using SchoolManagementSystem.Application.Teachers.Queries;

namespace SchoolManagementSystem.API.Controllers.V1
{
    [Authorize(Roles = "Admin,Teacher,Student,Psychologist")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PsychologistsController : ApiController
    {
        [HttpGet(ApiRoutesV1.Psychologist.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPsychologistsQuery();
            return Ok(await Mediator.Send(query));
        }

        [HttpGet(ApiRoutesV1.Psychologist.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string psychologistId)
        {
            var query = new GetPsychologistByIdQuery { Id = psychologistId };
            return Ok(await Mediator.Send(query));
        }
    }
}