using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Roles
{
    public static class RolErrors
    {
        public static Error NotFound = new Error("Rol.NotFound", "El rol con el Id especificado no fue encontrado");
        public static Error Exists = new Error("Rol.Exists", "El rol con la descripcion especificada ya existe");
        public static Error InvalidDescription = new Error("Rol.InvalidDescription", "Descripción de rol inválida");
        public static Error CreateError = new Error("Rol.CreateError", "Error al crear el rol");
    }
}
