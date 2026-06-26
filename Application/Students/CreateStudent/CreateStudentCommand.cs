using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Students.CreateStudent
{
    public record class CreateStudentCommand(int dni, string name, string lastname, string email, string phoneNumber) : ICommand<Guid>;
}
