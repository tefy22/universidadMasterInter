using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Subjects
{
    public record SubjectDto(Guid id, string name, int credits, Guid idTeacher, int estado);
}
