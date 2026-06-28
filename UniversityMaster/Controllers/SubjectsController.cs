using Application.Subjects.CreateSubject;
using Application.Subjects.SearchSubject;
using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UniversityMaster.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISender _sender;

        public SubjectsController(ISender sender)
        {
            _sender = sender;
        }

        //[HttpGet]
        //public async Task<IActionResult> SearchTeachers(CancellationToken cancellationToken = default)
        //{
        //    var query = new SearchAllTeacherQuery();
        //    var result = await _sender.Send(query, cancellationToken);
        //    if (result.IsFailure)
        //        return BadRequest(result.Error);

        //    var response = Result.Success(result.Value);

        //    return Ok(response);
        //}

        [HttpGet("{id:guid}", Name = "GetSubjectsById")]
        public async Task<IActionResult> SearchById(Guid id, CancellationToken cancellationToken = default)
        {
            var query = new SearchSubjectByIdQuery(id);
            var result = await _sender.Send(query, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(Result.Success(result.Value));
        }


        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] CreateSubjectCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return CreatedAtRoute("GetSubjectsById", new { id = result.Value }, Result.Success(result.Value));
        }
    }
}
