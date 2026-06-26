using Domain.Abstractions;
using Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Students
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Student?> GetByDniAsync(int dni, CancellationToken cancellationToken = default);
        Task<Student?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<Student?> GetByEmailByIdAsync(Guid id, string email, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken = default);
        void Add(Student student);
        Task<Result> Update(Student student);
        Task<Result> Delete(Guid id);

    }
}
