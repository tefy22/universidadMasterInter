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
        Task<Student?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Student>> GetAllAsync(CancellationToken cancellationToken = default);
        void AddAsync(Student student);
        bool UpdateAsync(Student student);
        bool DeleteAsync(Guid id);

    }
}
