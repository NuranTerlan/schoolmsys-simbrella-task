using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Contracts;
using SchoolManagementSystem.Application.TeacherClasses.Commands;
using SchoolManagementSystem.Application.TeacherClasses.Queries;

namespace SchoolManagementSystem.API.Controllers.V1
{
    [Authorize(Roles = "Admin,Teacher")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TeacherClassesController : ApiController
    {
        [HttpGet(ApiRoutesV1.TeacherClasses.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTeacherClassesQuery();
            return Ok(await Mediator.Send(query));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(ApiRoutesV1.TeacherClasses.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTeacherClassCommand command)
        {
            var result = await Mediator.Send(command);
            return Created(ApiRoutesV1.TeacherClasses.GetAll, result);
        }
    }
}