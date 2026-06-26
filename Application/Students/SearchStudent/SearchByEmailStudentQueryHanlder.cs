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
    internal sealed class SearchByEmailStudentQueryHanlder : ICommandHandler<SearchByEmailStudentQuery, StudentDto>
    {
        private readonly IStudentRepository _studentRepository;

        public SearchByEmailStudentQueryHanlder(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result<StudentDto>> Handle(SearchByEmailStudentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var student = await _studentRepository.GetByEmailAsync(request.email, cancellationToken);
                if (student is null)
                    return Result.Failure<StudentDto>(StudentErrors.NotFound);

                var dto = new StudentDto(student.Id, student.DNId.Value, student.Name.Value, student.LastName.Value, student.Email.Value, student.PhoneNumber.Value);
                return Result.Success<StudentDto>(dto);
            }
            catch (Exception)
            {
                return Result.Failure<StudentDto>(StudentErrors.SearchError);
            }
        }
    }
}
