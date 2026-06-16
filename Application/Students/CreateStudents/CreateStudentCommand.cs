using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.CreateStudents
{
    public record CreateStudentCommand(
        int id,
        string Name,
        string LastName,
        string Email,
        string PhoneNumber,
        string Password,
        Guid RolId
    ) : ICommand<Guid>;
}
