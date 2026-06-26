using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Students;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.CreateStudent
{
    internal sealed class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand, Guid>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
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

                if(dni.IsFailure)
                    return Result.Failure<Guid>(dni.Error);

                if (name.IsFailure)
                    return Result.Failure<Guid>(name.Error);

                if (lastname.IsFailure)
                    return Result.Failure<Guid>(lastname.Error);

                if (email.IsFailure)
                    return Result.Failure<Guid>(email.Error);

                if (phoneNumber.IsFailure)
                    return Result.Failure<Guid>(phoneNumber.Error);

                var existDni = await _studentRepository.GetByDniAsync(dni.Value.Value, cancellationToken);
                if (existDni is not null)
                    return Result.Failure<Guid>(StudentErrors.ExistsDni);

                var existEmail = await _studentRepository.GetByEmailAsync(email.Value.Value, cancellationToken);
                if (existEmail is not null)
                    return Result.Failure<Guid>(StudentErrors.ExistsEmail);

                var studentResult = Student.Create(dni.Value, name.Value, lastname.Value, email.Value, phoneNumber.Value);

                if (studentResult.IsFailure)
                    return Result.Failure<Guid>(studentResult.Error);

                _studentRepository.Add(studentResult.Value);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success(studentResult.Value.Id);

            }
            catch (Exception)
            {
                return Result.Failure<Guid>(StudentErrors.CreateError);
            }
        }
    }
}
