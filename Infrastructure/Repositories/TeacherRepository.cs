using Domain.Abstractions;
using Domain.Students;
using Domain.Teachers;
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
    internal sealed class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext dbContext): base(dbContext) { }
        
        public async Task<Result> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return Result.Failure(TeacherErrors.Empty);

            try
            {
                var teacherExist = await _dbContext.Set<Teacher>().FirstOrDefaultAsync(x => x.Id == id);
                if (teacherExist is null)
                    return Result.Failure(TeacherErrors.NotFound);

                _dbContext.Set<Teacher>().Remove(teacherExist);
                await _dbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Failure(TeacherErrors.DeleteError);
            }
        }

        public async Task<IReadOnlyList<Teacher>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Teacher>().ToListAsync();
        }

        public async Task<Teacher?> GetByDniAsync(int dni, CancellationToken cancellationToken = default)
        {
            var dniResult = DNI.Create(dni);
            if (dniResult.IsFailure)
                return null;

            DNI dniObject = dniResult.Value;

            return await _dbContext.Set<Teacher>().FirstOrDefaultAsync(s => s.DNId == dniObject, cancellationToken);
        }

        public async Task<Teacher?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var emailResult = Email.Create(email);

            if (emailResult.IsFailure)
                return null;

            var emailObjeto = emailResult.Value;

            return await _dbContext.Set<Teacher>().FirstOrDefaultAsync(s => s.Email == emailObjeto, cancellationToken);
        }

        public async Task<Teacher?> GetByEmailByIdAsync(Guid id, string email, CancellationToken cancellationToken = default)
        {
            var emailResult = Email.Create(email);

            if (emailResult.IsFailure)
                return null;

            var emailObjeto = emailResult.Value;

            return await _dbContext.Set<Teacher>().FirstOrDefaultAsync(s => s.Email == emailObjeto && s.Id != id, cancellationToken);
        }

        public async Task<Result> Update(Teacher teacher)
        {
            try
            {
                var exist = await _dbContext.Set<Teacher>().FirstOrDefaultAsync(s => s.Id == teacher.Id);

                if (exist is null)
                    return Result.Failure(TeacherErrors.NotFound);

                _dbContext.Entry(exist).CurrentValues.SetValues(teacher);
                await _dbContext.SaveChangesAsync();
                return Result.Success();

            }
            catch (Exception)
            {
                return Result.Failure(TeacherErrors.UpdateError);
            }
        }
    }
}
