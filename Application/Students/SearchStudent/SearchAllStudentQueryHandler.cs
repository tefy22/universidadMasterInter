using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.SearchStudent
{
    internal sealed class SearchAllStudentQueryHandler : ICommandHandler<SearchAllStudentQuery, IReadOnlyList<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;

        public SearchAllStudentQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result<IReadOnlyList<StudentDto>>> Handle(SearchAllStudentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var students = await _studentRepository.GetAllAsync(cancellationToken);
                var dtos = students
                    .Select(s => new StudentDto
                    (
                        id: s.Id,
                        dni: s.DNId.Value,
                        name: s.Name.Value,
                        lastname: s.LastName.Value,
                        email: s.Email.Value,
                        phoneNumber: s.PhoneNumber.Value
                    ))
                    .ToList();
                return Result.Success<IReadOnlyList<StudentDto>>(dtos);
            }
            catch (Exception)
            {
                return Result.Failure<IReadOnlyList<StudentDto>>(StudentErrors.SearchError);
            }
        }
    }
}
