using Application.Abstractions.Messaging;
using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.SearchStudents
{
    internal sealed class SearchStudentCommandHandler : ICommandHandler<SearchStudentCommand, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public SearchStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result<Student>> Handle(SearchStudentCommand request, CancellationToken cancellationToken)
        {
           return (Result<Student>) await _studentRepository.GetAllAsync(cancellationToken);
        }
    }
}
