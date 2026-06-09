using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Domain.ValueObjects
{
    public partial record Password
    {
        /*         
         Mínimo 8 caracteres.
        Al menos una letra mayúscula.
        Al menos una letra minúscula.
        Al menos un número.
         */
        private const int MinLength = 8;
        private const int MaxLength = 20;
        private const string Pattern = @"/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/";
        public string Value { get; private set; }
        private Password(string value) => Value = value;

        [GeneratedRegex(Pattern)]
        private static partial Regex PasswordRegex();
        public static Password Create(string value)
        {
            /*
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password cannot be empty.");
            
            if (value.Length < MinLength)
                throw new ArgumentException($"Password must be at least {MinLength} characters long.");
            falta evaluar que sea mayor a 20 caracteres
            if (!PasswordRegex().IsMatch(value))
                throw new ArgumentException("Password must contain at least one uppercase letter, one lowercase letter, and one number.");
            */
            if (string.IsNullOrWhiteSpace(value) || value.Length < MinLength || value.Length > MaxLength
                || !PasswordRegex().IsMatch(value))
                return null;
            return new Password(value);
        }
    }
}
