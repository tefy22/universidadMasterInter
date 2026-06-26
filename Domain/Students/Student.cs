using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public DateTime? CreatedAt { get; private set; }

        private Student()
        {
            
        }

        private Student(Guid id, DNI dni, Name name, LastName lastname, Email email,
            PhoneNumber phoneNumber) : base(id)
        {
            DNId = dni;
            Name = name;
            LastName = lastname;
            Email = email;
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.Now;
        }

        
        public static Result<Student> Create(DNI dni, Name name, LastName lastname, Email email, PhoneNumber phoneNumber)
        {
            return new Student(Guid.NewGuid(), dni, name, lastname, email, phoneNumber);            
        }

        public static Result<Student> Update(Guid id, DNI dni, Name name, LastName lastname, Email email, PhoneNumber phoneNumber)
        {
            return new Student(id, dni, name, lastname, email, phoneNumber);
        }

    }
}
