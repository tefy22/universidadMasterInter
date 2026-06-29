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
    internal sealed class SearchAllTeacherQueryHandler :ICommandHandler<SearchAllTeacherQuery, IReadOnlyList<TeacherDto>>
    {
        private readonly ITeacherRepository _teacherRepository;

        public SearchAllTeacherQueryHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Result<IReadOnlyList<TeacherDto>>> Handle(SearchAllTeacherQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var teachers = await _teacherRepository.GetAllAsync(cancellationToken);
                var dtos = teachers
                    .Select(s => new TeacherDto
                    (
                        id: s.Id,
                        dni: s.DNId.Value,
                        name: s.Name.Value,
                        lastname: s.LastName.Value,
                        email: s.Email.Value,
                        phoneNumber: s.PhoneNumber.Value
                    ))
                    .ToList();

                return Result.Success<IReadOnlyList<TeacherDto>>(dtos);
            }
            catch (Exception)
            {
                return Result.Failure<IReadOnlyList<TeacherDto>>(TeacherErrors.SearchError);
            }
        }
    }
}
