using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Students
{
    public sealed class Student : Entity
    {
        public Name Name { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Password Password { get; private set; }
        public Guid RolId { get; private set; }
        public StatusDetails Status { get; private set; } = StatusDetails.Active;
        public DateTime? CreatedAt { get; private set; }

        private Student(Guid id, Name name, LastName lastname, Email email,
            PhoneNumber phoneNumber, Password password, Guid idRol, 
            StatusDetails status) : base(id)
        {
            Name = name;
            LastName = lastname;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            RolId = idRol;
            Status = status;
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// creacion del estudiante, se genera un nuevo id para el estudiante y se asigna la fecha de creacion
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="password"></param>
        /// <param name="idRol"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static Student Create(
            Name name, LastName lastname, Email email, PhoneNumber phoneNumber,
            Password password, Guid idRol, StatusDetails status)
        {
            return new Student(Guid.NewGuid(), name, lastname, email, 
                phoneNumber, password, idRol, status);            
        }


    }
}
