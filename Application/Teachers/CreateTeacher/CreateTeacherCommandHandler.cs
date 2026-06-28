using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Teachers;
using Domain.Theachers;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teachers.CreateTeacher
{
    internal sealed class CreateTeacherCommandHandler : ICommandHandler<CreateTeacherCommand, Guid>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTeacherCommandHandler(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork)
        {
            _teacherRepository = teacherRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null)
                    return Result.Failure<Guid>(Error.NullValue);

                var dni = DNI.Create(request.dni);
                var name = Name.Create(request.name);
                var lastname = LastName.Create(request.lastname);
                var email = Email.Create(request.email);
                var phoneNumber = PhoneNumber.Create(request.phoneNumber);

                if (dni.IsFailure)
                    return Result.Failure<Guid>(dni.Error);

                if (name.IsFailure)
                    return Result.Failure<Guid>(name.Error);

                if (lastname.IsFailure)
                    return Result.Failure<Guid>(lastname.Error);

                if (email.IsFailure)
                    return Result.Failure<Guid>(email.Error);

                if (phoneNumber.IsFailure)
                    return Result.Failure<Guid>(phoneNumber.Error);

                var existDni = await _teacherRepository.GetByDniAsync(dni.Value.Value, cancellationToken);
                if (existDni is not null)
                    return Result.Failure<Guid>(TeacherErrors.ExistsDni);

                var existEmail = await _teacherRepository.GetByEmailAsync(email.Value.Value, cancellationToken);
                if(existEmail is not null)
                    return Result.Failure<Guid>(TeacherErrors.ExistsEmail);

                var teacherResult = Teacher.Create(dni.Value, name.Value, lastname.Value, email.Value, phoneNumber.Value);

                if (teacherResult.IsFailure)
                    return Result.Failure<Guid>(teacherResult.Error);

                _teacherRepository.Add(teacherResult.Value);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success(teacherResult.Value.Id);
            }
            catch (Exception)
            {
                return Result.Failure<Guid>(TeacherErrors.CreateError);
            }
        }
    }
}
