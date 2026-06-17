using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rol
{
    internal sealed class RolCreateCommandHanlder : ICommandHandler<RolCreateCommand, Guid>
    {
        private readonly IRolRepository _rolRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RolCreateCommandHanlder(IRolRepository rolRepository, IUnitOfWork unitOfWork)
        {
            _rolRepository = rolRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(RolCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null)
                    return Result<Guid>.Failure<Guid>(Error.NullValue);

                // Validar y convertir la descripción a enum RolesDetails
                if (!Enum.TryParse<RolesDetails>(request.Description, ignoreCase: true, out var descriptionEnum))
                    return Result<Guid>.Failure<Guid>(RolErrors.InvalidDescription);                

                // Verificar existencia por nombre (evitar duplicados)
                var exists = await _rolRepository.GetByNameAsync(descriptionEnum.ToString(), cancellationToken);
                if (exists is not null)
                    return Result<Guid>.Failure<Guid>(RolErrors.Exists);
                
                var rolResult = Domain.Roles.Rol.Create(descriptionEnum);
                if (!rolResult.IsSuccess)
                    return Result<Guid>.Failure<Guid>(rolResult.Error);
                

                var rol = rolResult.Value;

                _rolRepository.Add(rolResult.Value);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result<Guid>.Success(rol.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure<Guid>(RolErrors.CreateError);
            }
        }
    }
}
