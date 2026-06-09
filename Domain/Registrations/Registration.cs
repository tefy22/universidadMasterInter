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
        public Guid SubjectId { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public StatusDetails Status { get; private set; } = StatusDetails.Active;

        private Registration(Guid id, Guid studentId, Guid subjectId, DateTime registrationDate, StatusDetails status) : base(id)
        {
            StudentId = studentId;
            SubjectId = subjectId;
            RegistrationDate = registrationDate;
            Status = status;
        }

        /// <summary>
        /// creacion del registro de la materia, se genera un evento de dominio para indicar que se ha creado un nuevo registro
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="subjectId"></param>
        /// <param name="registrationDate"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static Registration Create(Guid studentId, Guid subjectId, DateTime registrationDate, StatusDetails status)
        {
            var registration = new Registration(Guid.NewGuid(), studentId, subjectId, registrationDate, status);
            
            registration.RaiseDomainEvent(new RegistrationCreateDomainEvent(registration.Id));

            return registration;
        }
    }
}
