using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Subjects
{
    public record SubjectDto(string name, int creditos, Guid idTeacher, int estado);
}
