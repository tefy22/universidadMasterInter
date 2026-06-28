using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teachers.CreateTeacher
{
    public record CreateTeacherCommand(int dni, string name, string lastname, string email, string phoneNumber) : ICommand<Guid>;
}
