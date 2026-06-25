using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.UpdateStudent
{
    public record UpdateStudentCommand(Guid id, int dni, string name, string lastName, string email, string phoneNumber) : ICommand<Guid>;
}
