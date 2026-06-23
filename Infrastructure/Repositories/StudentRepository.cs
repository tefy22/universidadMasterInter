using Domain.Abstractions;
using Domain.Students;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal sealed class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }



        public async Task<Result> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return Result.Failure(StudentErrors.Empty);

            try
            {
                var studentExist = GetByIdAsync(id, CancellationToken.None).GetAwaiter().GetResult();
                if (studentExist is null)
                    return Result.Failure(StudentErrors.NotFound);

                _dbContext.Set<Student>().Remove(studentExist);
                return Result.Success();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Student>().ToListAsync();
        }

        public async Task<Student?> GetByDniAsync(int dni, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Student>().FirstOrDefaultAsync(s => s.DNId.Value == dni, cancellationToken);
        }

        public async Task<Student?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Student>().FirstOrDefaultAsync(s => EF.Property<string>(s, nameof(Student.Email)) == email, cancellationToken);
        }

        public async Task<Result> Update(Student student)
        {
            try
            {
                var exist =  await _dbContext.Set<Student>().FirstOrDefaultAsync(r => r.Id == student.Id);
                if (exist is null)
                    return Result.Failure(StudentErrors.NotFound);

                _dbContext.Entry(exist).CurrentValues.SetValues(student);
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Failure(StudentErrors.UpdateError);
            }
        }

    }
}
