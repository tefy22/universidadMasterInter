using Application.Abstractions.Messaging;
using Domain.Theachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Teachers.SearchTeacher
{
    public record SearchByIdTeacherQuery(Guid id) : ICommand<TeacherDto>;
}
