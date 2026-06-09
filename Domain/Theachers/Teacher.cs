using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Theachers
{
    public sealed class Teacher : Entity
    {
        public Name Name { get; private set; }
        public LastName LastName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Email Email { get; private set; }    
        public Password Password { get; private set; }
        public Guid RolId { get; private set; }
        public StatusDetails Status { get; private set; } = StatusDetails.Active;
        public DateTime? CreatedAt { get; private set; }

        private Teacher(Guid id, Name name, LastName lastName, 
            PhoneNumber phoneNumber, Email email, Password password, 
            Guid idRol, StatusDetails status) : base(id)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            RolId = idRol;
            Status = status;
            CreatedAt = DateTime.Now;
        }
        /// <summary>
        /// creacion del profesor, se genera un nuevo id para el profesor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="idRol"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static Teacher Create(Name name, LastName lastName, PhoneNumber phoneNumber,
            Email email, Password password, Guid idRol, StatusDetails status, 
            DateTime? createAt)
        {
            return new Teacher(Guid.NewGuid(), name, lastName, phoneNumber,
                email, password, idRol, status);            
        }
    }
}
