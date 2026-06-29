using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teachers.DeleteTeacher
{
    internal sealed class DeleteTeacherCommandHandler : ICommandHandler<DeleteTeacherCommand>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeacherCommandHandler(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork)
        {
            _teacherRepository = teacherRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _teacherRepository.Delete(request.id);
                if (result.IsFailure)
                    return Result.Failure(TeacherErrors.DeleteError);

                await _unitOfWork.SaveChangesAsync();
                return Result.Success(result);
                
            }
            catch (Exception)
            {
                return Result.Failure(TeacherErrors.DeleteError);
            }
        }
    }
}
