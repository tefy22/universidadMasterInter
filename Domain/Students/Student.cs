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
        public DNI DNId { get; private set; }
        public Name Name { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Password Password { get; private set; }
        public Guid RolId { get; private set; }
        public StatusDetails Status { get; private set; } = StatusDetails.Active;
        public DateTime? CreatedAt { get; private set; }

        private Student()
        {
            
        }

        private Student(Guid id, DNI dni, Name name, LastName lastname, Email email,
            PhoneNumber phoneNumber, Password password, Guid idRol, 
            StatusDetails status) : base(id)
        {
            DNId = dni;
            Name = name;
            LastName = lastname;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            RolId = idRol;
            Status = status;
            CreatedAt = DateTime.Now;
        }

        
        public static Result<Student> Create(DNI dni, Name name, LastName lastname, Email email, PhoneNumber phoneNumber,
            Password password, Guid idRol)
        {
            return new Student(Guid.NewGuid(), dni, name, lastname, email, 
                phoneNumber, password, idRol, StatusDetails.Active);            
        }


    }
}
