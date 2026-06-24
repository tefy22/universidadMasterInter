using Application.Abstractions.Messaging;
using Domain.Students;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Students.SearchStudent
{
    public record SearchByDniStudentQuery(int dni) : ICommand<StudentDto>;
}
