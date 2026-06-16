using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Students
{
    public static class StudentErrors
    {
        public static Error NotFound = new Error("Student.NotFound","El estudiante con el Id especificado no fue encontrado");
        public static Error ExistsDni = new Error("Student.Exists", "El estudiante con la identificacion especificada ya existe");
        public static Error ExistsEmail = new Error("Student.Email", "El estudiante con el email especificado ya existe");
        public static Error Overlap = new Error("Student.Overlap", "El estudiante esta siendo registrado por otro agente en este momento");
    }
}
