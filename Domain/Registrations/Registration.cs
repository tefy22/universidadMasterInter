using Domain.Abstractions;
using Domain.Registrations.Events;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Registrations
{
    public sealed class Registration : Entity
    {
        public Guid StudentId { get; private set; }
        public List<Guid> SubjectId { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public StatusDetails Status { get; private set; } = StatusDetails.Active;

        private Registration(Guid id, Guid studentId, List<Guid> subjectId, DateTime registrationDate, StatusDetails status) : base(id)
        {
            StudentId = studentId;
            SubjectId = subjectId;
            RegistrationDate = registrationDate;
            Status = status;
        }

        public static Registration Create(Guid studentId, List<Guid> subjectId, DateTime registrationDate, StatusDetails status)
        {
            var registration = new Registration(Guid.NewGuid(), studentId, subjectId, registrationDate, status);
            
            registration.RaiseDomainEvent(new RegistrationCreateDomainEvent(registration.Id));

            return registration;
        }
    }
}
