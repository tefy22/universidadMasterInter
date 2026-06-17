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
        private Rol()
        {
            
        }

        private Rol(Guid id, RolesDetails description) : base(id)
        {
            Description = description;
        }
        public static Result<Rol> Create(RolesDetails description)
        {
            return new Rol(Guid.NewGuid(), description);
        }

    }
}
