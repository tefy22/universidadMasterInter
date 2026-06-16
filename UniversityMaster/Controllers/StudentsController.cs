using Application.Students.CreateStudents;
using Application.Students.SearchStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UniversityMaster.Controllers
{
    [ApiController]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        private readonly ISender _sender;

        public StudentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> SearchStudents(CancellationToken cancellationToken = default)
        {
            var query = new SearchStudentCommand();
            var result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            // Devuelve 201 con la localización para consultar al estudiante por id vía GET (query string)
            return CreatedAtAction(nameof(SearchStudents), new { id = result.Value }, result.Value);

        }
    }
}
