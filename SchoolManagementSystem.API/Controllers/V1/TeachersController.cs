using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Contracts;
using SchoolManagementSystem.Application.Teachers.Queries;

namespace SchoolManagementSystem.API.Controllers.V1
{
    [Authorize(Roles = "Admin,Teacher,Student")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TeachersController : ApiController
    {
        [HttpGet(ApiRoutesV1.Teachers.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTeachersQuery();
            return Ok(await Mediator.Send(query));
        }

        [HttpGet(ApiRoutesV1.Teachers.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string teacherId)
        {
            var query = new GetTeacherByIdQuery { Id = teacherId };
            return Ok(await Mediator.Send(query));
        }
    }
}