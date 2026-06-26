using Application.Abstractions.Messaging;
using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.SearchStudent
{
    public record class SearchByEmailStudentQuery (string email) : ICommand<StudentDto>;
    
}
