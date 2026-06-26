using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Theachers
{
    public record TeacherDto(Guid id, int dni, string name, string lastname, string email, string phoneNumber);
}
