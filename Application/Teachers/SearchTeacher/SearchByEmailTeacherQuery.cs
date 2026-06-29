using Application.Abstractions.Messaging;
using Domain.Theachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teachers.SearchTeacher
{
    public record SearchByEmailTeacherQuery(string email) : ICommand<TeacherDto>;
}
