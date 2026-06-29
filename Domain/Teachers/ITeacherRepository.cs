using Domain.Abstractions;
using Domain.Theachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Teachers
{
    public interface ITeacherRepository
    {
        Task<Teacher?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Teacher?> GetByDniAsync(int dni, CancellationToken cancellationToken = default);
        Task<Teacher?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<Teacher?> GetByEmailByIdAsync(Guid id, string email, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Teacher>> GetAllAsync(CancellationToken cancellationToken = default);
        void Add(Teacher teacher);
        Task<Result> Update(Teacher teacher);
        Task<Result> Delete(Guid id);
    }
}
