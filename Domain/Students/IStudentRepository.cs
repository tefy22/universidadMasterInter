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
        Task<StudentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<StudentDto?> GetByDniAsync(int dni, CancellationToken cancellationToken = default);
        Task<StudentDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<StudentDto>> GetAllAsync(CancellationToken cancellationToken = default);
        void Add(Student student);
        Task<Result> Update(StudentDto student);
        Task<Result> Delete(Guid id);

    }
}
