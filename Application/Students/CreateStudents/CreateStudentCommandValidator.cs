using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.CreateStudents
{
    public class CreateStudentCommandValidator :AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(c => c.id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();    
            RuleFor(c=> c.Email).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty();
            RuleFor(c => c.Password).NotEmpty();
            RuleFor(s => s.RolId).NotEmpty();

        }
    }
}
