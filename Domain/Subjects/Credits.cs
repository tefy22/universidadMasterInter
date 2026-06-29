using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Subjects
{
    public sealed record Credits
    {
        private const int MinCredits = 3;
        public int Value { get; init; }
        private Credits(int value) => Value = value;

        public static Result<Credits> Create(int value)
        {
            if (value != MinCredits)
                throw new ApplicationException($"El valor de los creditos debe ser {MinCredits} por cada materia.");

            return new Credits(value);
        }
    }
}
