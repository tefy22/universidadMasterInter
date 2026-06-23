using Application.Students.CreateStudent;
using Application.Students.SearchStudent;
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

        [HttpGet("{id}", Name = "GetStudentsById")]
        public async Task<IActionResult> SearchById(Guid id, CancellationToken cancellationToken = default)
        {
            var command = new SearchByIdStudentQuery(id);
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
    }
}
