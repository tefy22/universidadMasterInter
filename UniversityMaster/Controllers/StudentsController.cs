using Application.Students.CreateStudent;
using Application.Students.DeleteStudent;
using Application.Students.SearchStudent;
using Application.Students.UpdateStudent;
using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UniversityMaster.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        public readonly ISender _sender;

        public StudentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> SearchStudents(CancellationToken cancellation = default)
        {
            var query = new SearchAllStudentQuery();
            var result = await _sender.Send(query, cancellation);
            if (result.IsFailure)
                return BadRequest(result.Error);

            var response = Result.Success(result.Value);
            return Ok(response);
        }

        [HttpGet("{id:guid}", Name = "GetStudentsById")]
        public async Task<IActionResult> SearchById(Guid id, CancellationToken cancellationToken = default)
        {
            var command = new SearchByIdStudentQuery(id);
            var result = await _sender.Send(command, cancellationToken);

            if(result.IsFailure)
                return BadRequest(result.Error);

            return Ok(Result.Success(result.Value));
        }

        [HttpGet("{dni:int}", Name = "GetStudentByDni")]
        public async Task<IActionResult> SearchByDni(int dni, CancellationToken cancellationToken = default)
        {
            var command = new SearchByDniStudentQuery(dni);
            var result = await _sender.Send(command, cancellationToken);
            if(result.IsFailure)
                return BadRequest(result.Error);
            return Ok(Result.Success(result.Value));
        }

        [HttpGet("{email}", Name = "GetStudentByEmail")]
        public async Task<IActionResult> SearchByEmail(string email, CancellationToken cancellationToken = default)
        {
            var command = new SearchByEmailStudentQuery(email);
            var result = await _sender.Send(command, cancellationToken);

            if(result.IsFailure)
                return BadRequest(result.Error);

            return Ok(Result.Success(result.Value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudents([FromBody] CreateStudentCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return CreatedAtRoute("GetStudentsById", new {id = result.Value}, Result.Success(result.Value));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteStudentCommand(id);
            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] UpdateStudentCommand command, CancellationToken cancellationToken = default)
        {
            var request = new UpdateStudentCommand(id, command.dni, command.name, command.lastName, command.email, command.phoneNumber);
            var result = await _sender.Send(request, cancellationToken);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return Ok(Result.Success(result.Value));
        }
    }
}
