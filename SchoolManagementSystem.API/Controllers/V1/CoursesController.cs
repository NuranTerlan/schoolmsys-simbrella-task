using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Contracts;
using SchoolManagementSystem.Application.Courses.Commands;
using SchoolManagementSystem.Application.Courses.Queries;

namespace SchoolManagementSystem.API.Controllers.V1
{
    [Authorize(Roles = "Admin,Student,Teacher")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CoursesController : ApiController
    {
        [HttpGet(ApiRoutesV1.Courses.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCoursesQuery();
            return Ok(await Mediator.Send(query));
        }

        [HttpGet(ApiRoutesV1.Courses.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int courseId)
        {
            var query = new GetCourseByIdQuery {Id = courseId};
            return Ok(await Mediator.Send(query));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(ApiRoutesV1.Courses.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCourseCommand command)
        {
            var result = await Mediator.Send(command);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri =
                $"{baseUrl}/{ApiRoutesV1.Courses.GetById.Replace("{courseId}", result.Data.Id.ToString())}";

            return Created(locationUri, result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(ApiRoutesV1.Courses.Update)]
        public async Task<IActionResult> Update([FromRoute] int courseId,
            [FromBody] UpdateCourseCommand command)
        {
            command.Id = courseId;
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(ApiRoutesV1.Courses.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int courseId)
        {
            var command = new DeleteCourseCommand {Id = courseId};
            return Ok(await Mediator.Send(command));
        }
    }
}