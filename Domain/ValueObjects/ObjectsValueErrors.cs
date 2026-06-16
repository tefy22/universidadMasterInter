using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public static class ObjectsValueErrors
    {
        #region DNI

        public static Error DNIEmpty = new Error("DNI.Empty", "la identificacion no puede ser vacia");
        public static Error DNIInvalid = new Error("DNI.Invalid", "la identificacion no es valida");

        #endregion

        #region Name

        public static Error NameEmpty = new Error("Name.Empty", "El nombre no puede ser vacio");

        #endregion

        #region LastName

        public static Error LastNameEmpty = new Error("LastName.Empty", "El apellido no puede ser vacio");

        #endregion

        #region EmailErrors

        public static Error EmailEmpty = new Error("Email.Empty", "El email no puede ser vacio");
        public static Error EmailInvalid = new Error("Email.Invalid", "El email no tiene un formato válido");

        #endregion

        #region PasswordErrors

        public static Error PasswordEmpty = new Error("Password.Empty", "La contraseña no puede ser vacio");
        public static Error PasswordLength = new Error("Password.Length", "La contraseña no cumple con la longitud minima o máxima establecida");
        public static Error PasswordCharacter = new Error("Password.Character", "La contraseña debe tener una longitud de minimo 8 caracteres y maximo 20 caracteres, Adicional debe contener al menos una letra en mayuscula, una letra en minuscula y un numero.");

        #endregion


        #region PhoneNumbersErrors

        public static Error PhoneNumbersEmpty = new Error("PhoneNumbers.Empty", "El telefono no puede ser vacio");
        public static Error PhoneNumbersLength = new Error("PhoneNumbers.Length", "El telefono no cumple con la longitud minima establecida");
        public static Error PhoneNumbersStart = new Error("PhoneNumbers.Start", "El telefono debe iniciar con 3 y contener solo digitos");

        #endregion


    }
}
