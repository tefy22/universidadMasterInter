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

namespace Application.Teachers.UpdateTeacher
{
    internal sealed class UpdateTeacherCommandHandler : ICommandHandler<UpdateTeacherCommand, Guid>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTeacherCommandHandler(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork)
        {
            _teacherRepository = teacherRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return Result.Failure<Guid>(Error.NullValue);

                var dni = DNI.Create(request.dni);
                var name = Name.Create(request.name);
                var lastname = LastName.Create(request.lastName);
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

                var exist = await _teacherRepository.GetByIdAsync(request.id, cancellationToken);

                var existEmail = await _teacherRepository.GetByEmailByIdAsync(request.id, email.Value.Value, cancellationToken);
                if (existEmail is not null)
                    return Result.Failure<Guid>(TeacherErrors.ExistsEmail);

                var dniExits = DNI.Create(exist.DNId.Value);
                var emailExits = Email.Create(exist.Email.Value);

                var teacherResult = Teacher.Update(request.id, dniExits.Value, name.Value, lastname.Value, emailExits.Value, phoneNumber.Value);
                if (teacherResult.IsFailure)
                    return Result.Failure<Guid>(teacherResult.Error);

                var updateResult = await _teacherRepository.Update(teacherResult.Value);
                if (updateResult.IsFailure)
                    return Result.Failure<Guid>(updateResult.Error);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success(teacherResult.Value.Id);

            }
            catch (Exception)
            {
                return Result.Failure<Guid>(TeacherErrors.UpdateError);
            }
        }
    }
}
