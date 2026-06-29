using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Teachers
{
    public static class TeacherErrors
    {
        public static Error Empty = new Error("Teacher.Empty", "El docente con el Id especificado no puede ser vacio");
        public static Error NotFound = new Error("Teacher.NotFound", "El docente con el Id especificado no fue encontrado");
        public static Error ExistsDni = new Error("Teacher.Exists", "El docente con la identificacion especificada ya existe");
        public static Error ExistsEmail = new Error("Teacher.Email", "El docente con el email especificado ya existe");
        public static Error Overlap = new Error("Teacher.Overlap", "El docente esta siendo registrado por otro agente en este momento");
        public static Error CreateError = new Error("Teacher.CreateError", "Error al crear el docente");
        public static Error UpdateError = new Error("Teacher.UpdateError", "Error al actualizar el docente");
        public static Error DeleteError = new Error("Teacher.DeleteError", "Error al eliminar el docente");
        public static Error SearchError = new Error("Teacher.SearchError", "Ocurrio un error al buscar el docente");
    }
}
