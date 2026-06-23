using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.CreateStudent
{
    public class CreateStudentCommandValidator :AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(c => c.dni).NotEmpty().WithMessage("El DNI del estudiante no puede estar vacío.");
            RuleFor(c => c.name).NotEmpty().WithMessage("El nombre del estudiante no puede estar vacío.");
            RuleFor(c => c.lastname).NotEmpty().WithMessage("El apellido del estudiante no puede estar vacío.");
            RuleFor(c => c.email).NotEmpty().WithMessage("El correo electrónico del estudiante no puede estar vacío.")
                .EmailAddress().WithMessage("El correo electrónico no es válido.");
            RuleFor(c => c.phoneNumber).NotEmpty().WithMessage("El número de teléfono del estudiante no puede estar vacío.");
        }
    }
}
