using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Students
{
    public record StudentDto(Guid id, int dni, string name, string lastname, string phoneNumber);
}
