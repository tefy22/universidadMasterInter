using Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rol
{
    public record RolCreateCommand(int id, string Description) : ICommand<Guid>;
}
