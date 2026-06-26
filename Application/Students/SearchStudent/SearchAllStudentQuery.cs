using Application.Abstractions.Messaging;
using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Students.SearchStudent
{
    public record SearchAllStudentQuery(): ICommand<IReadOnlyList<StudentDto>>;
}
