using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Roles
{
    public interface IRolRepository
    {
        Task<Rol?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Rol>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Rol?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        void Add(Rol rol);
        Task<Result> Update(Rol rol);
        Task<Result> Delete(Guid id);

    }
}
