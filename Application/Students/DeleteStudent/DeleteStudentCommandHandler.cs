using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.DeleteStudent
{
    internal sealed class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _studentRepository.Delete(request.id);

                if (result.IsFailure)
                    return Result.Failure(StudentErrors.DeleteError);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Success(result);

            }
            catch (Exception)
            {
                return Result.Failure(StudentErrors.DeleteError);
            }
        }
    }
}
