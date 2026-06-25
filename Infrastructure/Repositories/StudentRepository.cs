using Domain.Abstractions;
using Domain.Students;
using Domain.ValueObjects;
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
                var studentExist = await _dbContext.Set<Student>().FirstOrDefaultAsync(s => s.Id == id);
                if (studentExist is null)
                    return Result.Failure(StudentErrors.NotFound);

                _dbContext.Set<Student>().Remove(studentExist);
                await _dbContext.SaveChangesAsync();
                return Result.Success();

            }
            catch (Exception)
            {
                return Result.Failure(StudentErrors.DeleteError);
            }
        }

        public async Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Student>().ToListAsync();
        }

        public async Task<Student?> GetByDniAsync(int dni, CancellationToken cancellationToken = default)
        {
            //Validamos y creamos el Value Object usando tu método de dominio
            var dniResult = DNI.Create(dni);

            if (dniResult.IsFailure)
                return null;

            DNI dniObjeto = dniResult.Value;

            //Comparamos Objeto 'DNI' contra Objeto 'DNI' EF Core lo traduce a SQL.
            return await _dbContext.Set<Student>().FirstOrDefaultAsync(s => s.DNId == dniObjeto, cancellationToken);        
        }

        public async Task<Student?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var emailResult = Email.Create(email);

            if (emailResult.IsFailure)
                return null;

            var emailObjeto = emailResult.Value;

            return await _dbContext.Set<Student>().FirstOrDefaultAsync(s => s.Email == emailObjeto , cancellationToken);
        }

        public async Task<Student?> GetByEmailByIdAsync(Guid id, string email, CancellationToken cancellationToken = default)
        {
            var emailResult = Email.Create(email);

            if (emailResult.IsFailure)
                return null;

            var emailObjeto = emailResult.Value;

            return await _dbContext.Set<Student>().FirstOrDefaultAsync(s => s.Email == emailObjeto && s.Id != id, cancellationToken);
        }

        public async Task<Result> Update(Student student)
        {
            try
            {
                var exist = await _dbContext.Set<Student>().FirstOrDefaultAsync(s => s.Id == student.Id);
                if (exist is null)
                    return Result.Failure(StudentErrors.NotFound);

                _dbContext.Entry(exist).CurrentValues.SetValues(student);
                return Result.Success();


                var studentExist = await _dbContext.Set<Student>().FirstOrDefaultAsync(s => s.Id == id);
                if (studentExist is null)
                    return Result.Failure(StudentErrors.NotFound);

                _dbContext.Set<Student>().Remove(studentExist);
                await _dbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Failure(StudentErrors.UpdateError);
            }
        }

    }
}
