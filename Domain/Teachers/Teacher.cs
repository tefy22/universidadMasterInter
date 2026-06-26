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
        public DNI DNId { get; private set; }
        public Name Name { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }    
        public PhoneNumber PhoneNumber { get; private set; }
        public DateTime? CreatedAt { get; private set; }

        private Teacher(Guid id, DNI dni, Name name, LastName lastName,
            Email email, PhoneNumber phoneNumber) : base(id)
        {
            DNId = dni; 
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            CreatedAt = DateTime.Now;
        }        

        public static Result<Teacher> Create(DNI dni,Name name, LastName lastName, Email email, PhoneNumber phoneNumber)
        {
            return new Teacher(Guid.NewGuid(), dni, name, lastName, email, phoneNumber);            
        }

        public static Result<Teacher> Update(Guid id, DNI dni, Name name, LastName lastName, Email email, PhoneNumber phoneNumber)
        {
            return new Teacher(id, dni, name, lastName, email, phoneNumber);
        }
    }
}
