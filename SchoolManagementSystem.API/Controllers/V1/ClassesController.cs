using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Contracts;
using SchoolManagementSystem.Application.SchoolClasses.Commands;
using SchoolManagementSystem.Application.SchoolClasses.Queries;

namespace SchoolManagementSystem.API.Controllers.V1
{
    public class ClassesController : ApiController
    {
        [HttpGet(ApiRoutesV1.SchoolClasses.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSchoolClassesQuery();
            return Ok(await Mediator.Send(query));
        }

        [HttpGet(ApiRoutesV1.SchoolClasses.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int classId)
        {
            var query = new GetSchoolClassByIdQuery {Id = classId};
            return Ok(await Mediator.Send(query));
        }

        [HttpPost(ApiRoutesV1.SchoolClasses.Create)]
        public async Task<IActionResult> Create([FromBody] CreateSchoolClassCommand command)
        {
            var result = await Mediator.Send(command);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = $"{baseUrl}/" +
                              $"{ApiRoutesV1.SchoolClasses.GetById.Replace("classId", result.Data.Id.ToString())}";
            return Created(locationUri, result);
        }

        [HttpPut(ApiRoutesV1.SchoolClasses.Update)]
        public async Task<IActionResult> Update([FromRoute] int classId,
            [FromBody] UpdateSchoolClassCommand command)
        {
            command.Id = classId;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete(ApiRoutesV1.SchoolClasses.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int classId)
        {
            var query = new DeleteSchoolClassCommand {Id = classId};
            return Ok(await Mediator.Send(query));
        }
    }
}