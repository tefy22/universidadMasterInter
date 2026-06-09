using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Subjects
{
    public sealed class Subject : Entity
    {
        public Name Name { get; private set; }
        public Credits Credits { get; private set; }
        public Guid TheacherId { get; private set; }
        public StatusDetails Status { get; private set; } = StatusDetails.Active;

        private Subject(Guid id, Name name, Credits credits, 
            Guid theacherId, StatusDetails status) : base(id)
        {
            Name = name;
            Credits = credits;
            TheacherId = theacherId;
            Status = status;
        }

        /// <summary>
        /// creacion de la materia, se asigna un nuevo guid para el id, y se asigna el estado activo por defecto
        /// </summary>
        /// <param name="name"></param>
        /// <param name="credits"></param>
        /// <param name="theacherId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static Subject Create(Name name, Credits credits, Guid theacherId, StatusDetails status)
        {
            return new Subject(Guid.NewGuid(), name, credits, theacherId, status);
        }
    }
}
