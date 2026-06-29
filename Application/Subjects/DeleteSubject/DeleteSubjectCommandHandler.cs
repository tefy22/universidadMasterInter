using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Subjects;
using Domain.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Subjects.DeleteSubject
{
    internal sealed class DeleteSubjectCommandHandler : ICommandHandler<DeleteSubjectCommand>
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSubjectCommandHandler(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
        {
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _subjectRepository.Delete(request.id);
                if (result.IsFailure)
                    return Result.Failure(SubjectErrors.DeleteError);

                await _unitOfWork.SaveChangesAsync();
                return Result.Success(result);
            }
            catch (Exception)
            {
                return Result.Failure(SubjectErrors.DeleteError);
            }
        }
    }
}
