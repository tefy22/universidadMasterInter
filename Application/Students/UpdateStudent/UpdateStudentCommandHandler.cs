using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Students;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.UpdateStudent
{
    internal sealed class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand, Guid>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
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

                var exist = await _studentRepository.GetByIdAsync(request.id, cancellationToken);
                //if (exist is not null)
                //    return Result.Failure<Guid>(StudentErrors.ExistsDni);

                var existEmail = await _studentRepository.GetByEmailByIdAsync(request.id, email.Value.Value, cancellationToken);
                if (existEmail is not null)
                    return Result.Failure<Guid>(StudentErrors.ExistsEmail);

                var dniExits  =DNI.Create(exist.DNId.Value);
                var emailExits = Email.Create(exist.Email.Value);

                var studentResult = Student.Update(request.id, dniExits.Value, name.Value, lastname.Value, emailExits.Value, phoneNumber.Value);

                if (studentResult.IsFailure)
                    return Result.Failure<Guid>(studentResult.Error);

                var updateResult = await _studentRepository.Update(studentResult.Value);
                if (updateResult.IsFailure)
                    return Result.Failure<Guid>(updateResult.Error);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success(studentResult.Value.Id);

            }
            catch (Exception)
            {
                return Result.Failure<Guid>(StudentErrors.UpdateError);
            }
        }
    }
}
