using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public partial record PhoneNumber
    {
        private const int MaxLength = 10;   
        private const string Pattern = @"^3\d{9}$";
        public string Value { get; private set; }
        private PhoneNumber(string value) => Value = value;

        [GeneratedRegex(Pattern)]
        private static partial Regex PhoneNumberRegex();

        public static PhoneNumber Create(string value)
        {
            /*
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be empty.");
            
            if (value.Length != MaxLength)
                throw new ArgumentException($"Phone number must be {MaxLength} digits long.");
            
            if (!PhoneNumberRegex().IsMatch(value))
                throw new ArgumentException("Phone number must start with '3' and contain only digits.");
            
            */

            if (string.IsNullOrWhiteSpace(value) || value.Length != MaxLength
                || !PhoneNumberRegex().IsMatch(value))
                return null;

            return new PhoneNumber(value);
        }

    }
}
