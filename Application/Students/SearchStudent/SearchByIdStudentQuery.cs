using Application.Abstractions.Messaging;
using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.SearchStudent
{
    public record SearchByIdStudentQuery(Guid id) : ICommand<StudentDto> ;
}
