using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Students;
using Domain.Teachers;
using Domain.Theachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teachers.SearchTeacher
{
    internal sealed class SearchByDniTeacherQueryHandler : ICommandHandler<SearchByDniTeacherQuery, TeacherDto>
    {
        private readonly ITeacherRepository _teacherRepository;

        public SearchByDniTeacherQueryHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Result<TeacherDto>> Handle(SearchByDniTeacherQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var teacher = await _teacherRepository.GetByDniAsync(request.dni, cancellationToken);
                if (teacher is null)
                    return Result.Failure<TeacherDto>(TeacherErrors.NotFound);

                var dto = new TeacherDto(teacher.Id, teacher.DNId.Value, teacher.Name.Value, teacher.LastName.Value, teacher.Email.Value, teacher.PhoneNumber.Value);
                return Result.Success<TeacherDto>(dto);
            }
            catch (Exception)
            {
                return Result.Failure<TeacherDto>(TeacherErrors.SearchError);
            }
        }
    }
}
