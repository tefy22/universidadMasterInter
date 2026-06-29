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

        private Subject()
        {
            
        }

        private Subject(Guid id, Name name, Credits credits, Guid theacherId, StatusDetails status) : base(id)
        {
            Name = name;
            Credits = credits;
            TheacherId = theacherId;
            Status = status;
        }
        public static Result<Subject> Create(Name name, Credits credits, Guid theacherId)
        {
            return new Subject(Guid.NewGuid(), name, credits, theacherId, StatusDetails.Active);
        }

        public static Result<Subject> Update(Guid id, Name name, Credits credits, Guid theacherId, StatusDetails status)
        {
            return new Subject(id, name, credits, theacherId, status);
        }
    }
}
