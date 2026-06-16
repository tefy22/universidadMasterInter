using Domain.Students;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal sealed class StudentRepository : Repository<Student> ,IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Student>().ToListAsync();
        }

        public async Task<Student?> GetByDniAsync(int dni, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Student>().FirstOrDefaultAsync(x => x.DNId.Value == dni, cancellationToken);
        }

        public async Task<Student?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Student>().FirstOrDefaultAsync(x => x.Email.Value == email, cancellationToken);
        }

        public bool Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
