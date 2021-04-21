using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Contracts;
using SchoolManagementSystem.Application.Students.Queries;

namespace SchoolManagementSystem.API.Controllers.V1
{
    [Authorize(Roles = "Admin,Teacher")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentsController : ApiController
    {
        [HttpGet(ApiRoutesV1.Students.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllStudentsQuery();
            return Ok(await Mediator.Send(query));
        }

        [HttpGet(ApiRoutesV1.Students.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string studentId)
        {
            var query = new GetStudentByIdQuery {Id = studentId};
            return Ok(await Mediator.Send(query));
        }
    }
}