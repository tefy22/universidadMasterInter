using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teachers.UpdateTeacher
{
    public record UpdateTeacherCommand(Guid id, int dni, string name, string lastName, string email, string phoneNumber) : ICommand<Guid>;
}
