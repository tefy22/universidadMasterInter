using Domain.Abstractions;
using Domain.Subjects;
using Domain.Theachers;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal sealed class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        public Task<Result> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Subject>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Subject>().ToListAsync();
        }

        public async Task<Subject?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            string searchPattern = $"%{name}%";
            return await _dbContext.Set<Subject>().FirstOrDefaultAsync(s => EF.Functions.Like(s.Name.Value, searchPattern), cancellationToken);
        }

        public async Task<IReadOnlyList<Subject>> GetOnlyActive(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Subject>().Where(s => s.Status == StatusDetails.Active).ToListAsync();
        }

        public async Task<IReadOnlyList<Subject>> GetSubjectForTeacher(Guid idTeacher, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Subject>().Where(s => s.TheacherId == idTeacher).ToListAsync(cancellationToken);
        }

        public Task<Result> Update(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
