using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Subjects;
using Domain.Teachers;
using Domain.Theachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Subjects.SearchSubject
{
    internal sealed class SearchSubjectByIdQueryHandler : ICommandHandler<SearchSubjectByIdQuery, SubjectDto>
    {
        private readonly ISubjectRepository _subjectRepository;

        public SearchSubjectByIdQueryHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Result<SubjectDto>> Handle(SearchSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var subject = await _subjectRepository.GetByIdAsync(request.id, cancellationToken);
                if (subject is null)
                    return Result.Failure<SubjectDto>(SubjectErrors.NotFound);

                var dto = new SubjectDto(subject.Name.Value, subject.Credits.Value, subject.TheacherId, (int)subject.Status);
                return Result.Success(dto);
            }
            catch (Exception)
            {
                return Result.Failure<SubjectDto>(SubjectErrors.SearchError);
            }
        }
    }
}
