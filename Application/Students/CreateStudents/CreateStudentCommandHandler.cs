using Application.Abstractions.Messaging;
using Application.Exceptions;
using Domain.Abstractions;
using Domain.Roles;
using Domain.Students;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.CreateStudents
{
    internal sealed class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand, Guid>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Result<Guid>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var idResult = DNI.Create(request.id);
            var nameResult = Name.Create(request.Name);
            var lastnameResult = LastName.Create(request.LastName);
            var emailResult = Email.Create(request.Email);
            var phoneNumberResult = PhoneNumber.Create(request.PhoneNumber);
            var passwordResult = Password.Create(request.Password);
            
            if (idResult.IsFailure)
                return Result.Failure<Guid>(idResult.Error);

            if (nameResult.IsFailure)
                return Result.Failure<Guid>(nameResult.Error);

            if (lastnameResult.IsFailure)
                return Result.Failure<Guid>(lastnameResult.Error);

            if (emailResult.IsFailure)
                return Result.Failure<Guid>(emailResult.Error);

            if (phoneNumberResult.IsFailure)
                return Result.Failure<Guid>(phoneNumberResult.Error);

            if (passwordResult.IsFailure)
                return Result.Failure<Guid>(passwordResult.Error);

            var userDNI = _studentRepository.GetByDniAsync(idResult.Value.Value);
            if (userDNI != null)
                return Result.Failure<Guid>(StudentErrors.ExistsDni);

            var userEmail = _studentRepository.GetByEmailAsync(emailResult.Value.Value);
            if (userEmail != null)
                return Result.Failure<Guid>(StudentErrors.ExistsEmail);

            try
            {
                var studentResult = Student.Create(
                idResult.Value,
                nameResult.Value,
                lastnameResult.Value,
                emailResult.Value,
                phoneNumberResult.Value,
                passwordResult.Value,
                request.RolId
                );

                if (studentResult.IsFailure)
                    return Result.Failure<Guid>(studentResult.Error);

                var student = studentResult.Value;

                _studentRepository.Add(student);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success(student.Id);
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(StudentErrors.Overlap);
            }
            
        }
    }
}

