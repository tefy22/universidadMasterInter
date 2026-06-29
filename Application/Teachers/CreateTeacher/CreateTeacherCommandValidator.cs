using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teachers.CreateTeacher
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        public CreateTeacherCommandValidator()
        {
            RuleFor(c => c.dni).NotEmpty().WithMessage("El DNI del profesor no puede ser vacio");
            RuleFor(c => c.name).NotEmpty().WithMessage("El nombre del profesor no puede estar vacío.");
            RuleFor(c => c.lastname).NotEmpty().WithMessage("El apellido del profesor no puede estar vacío.");
            RuleFor(c => c.email).NotEmpty().WithMessage("El correo electrónico del profesor no puede estar vacío.")
                .EmailAddress().WithMessage("El correo electrónico no es válido.");
            RuleFor(c => c.phoneNumber).NotEmpty().WithMessage("El número de teléfono del profesor no puede estar vacío.");
        }
    }
}
