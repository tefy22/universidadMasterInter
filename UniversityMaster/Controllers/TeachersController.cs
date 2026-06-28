using Application.Teachers.CreateTeacher;
using Application.Teachers.DeleteTeacher;
using Application.Teachers.SearchTeacher;
using Application.Teachers.UpdateTeacher;
using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UniversityMaster.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly ISender _sender;

        public TeachersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> SearchTeachers(CancellationToken cancellationToken = default)
        {
            var query = new SearchAllTeacherQuery();
            var result = await _sender.Send(query, cancellationToken);
            if(result.IsFailure)
                return BadRequest(result.Error);

            var response = Result.Success(result.Value);

            return Ok(response);
        }

        [HttpGet("{id:guid}", Name = "GetTeachersById")]
        public async Task<IActionResult> SearchById(Guid id, CancellationToken cancellationToken = default)
        {
            var query = new SearchByIdTeacherQuery(id);
            var result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(Result.Success(result.Value));
        }

        [HttpGet("{dni:int}", Name = "GetTeachersByDni")]
        public async Task<IActionResult> SearchByDni(int dni, CancellationToken cancellationToken = default)
        {
            var query = new SearchByDniTeacherQuery(dni);
            var result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(Result.Success(result.Value));
        }

        [HttpGet("{email}", Name = "GetTeachersByEmail")]
        public async Task<IActionResult> SearchByEmail(string email, CancellationToken cancellationToken = default)
        {
            var query = new SearchByEmailTeacherQuery(email);
            var result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(Result.Success(result.Value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeachers([FromBody] CreateTeacherCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return CreatedAtRoute("GetTeachersById", new { id = result.Value }, Result.Success(result.Value));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTeacher(Guid id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteTeacherCommand(id);
            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTeacher(Guid id, UpdateTeacherCommand command, CancellationToken cancellationToken = default)
        {
            var request = new UpdateTeacherCommand(id, command.dni, command.name, command.lastName, command.email, command.phoneNumber);

            var result = await _sender.Send(request, cancellationToken);
            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(Result.Success(result.Value));
        }
    }
}
