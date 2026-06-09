using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Roles
{
    public sealed class Rol : Entity
    {
        public RolesDetails Description { get; private set; }
        private Rol(Guid id, RolesDetails description) : base(id)
        {
            Description = description;
        }

        /// <summary>
        /// creación de rol, se genera un nuevo guid para el id y se asigna el nombre del rol (admin, teacher, student)
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static Rol Create(RolesDetails description)
        {
            return new Rol(Guid.NewGuid(), description);
        }

    }
}
