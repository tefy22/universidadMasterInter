using Domain.Abstractions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public sealed class User : Entity
    {
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Guid PersonId { get; private set; }
        public Guid RolId { get; private set; }
        public StatusDetails Status { get; private set; } = StatusDetails.Active;

        private User()
        {

        }
        private User(Email email, Password password, Guid personId, Guid rolId, StatusDetails status)
        {
            Email = email;
            Password = password;
            PersonId = personId;
            RolId = rolId;
            Status = status;
        }

        public static Result<User> Create(Email email, Password password, Guid personId, Guid rolId)
        {
            return new User(email, password, personId, rolId, StatusDetails.Active);
        }
    }
}
