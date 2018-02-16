using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Validations
{
    class PasswordValidation<T> : IValidationRule<T>
    {
        public string ValidateMessage { get; set; }

        public bool Check(string value, string password="")
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                ValidateMessage = "Le champ mot de passe est vide";
                return false;
            }
            if (PasswordHasNotMoreThanTenCharacters(value))
            {
                ValidateMessage = "Le mot de passe contient moins que 10 caractères. ";
                return false;
            }
            if (PasswordContainsCapitalsLetter(value))
            {
                ValidateMessage = "Le mot de passe passe ne contient pas au moins une lettre majuscule. ";
                return false;
            }
            if (PasswordContainsLowerLetter(value))
            {
                ValidateMessage = "Le mot de passe passe ne contient pas au moins une lettre minuscule. ";
                return false;
            }
            if (PasswordContainsDigital(value))
            {
                ValidateMessage = "Le mot de passe passe ne contient pas au moins un chiffre. ";
                return false;
            }
            return true;
        }

        private bool PasswordContainsLowerLetter(string value)
        {
            foreach (var character in value)
            {
                if (char.IsLower(character))
                {
                    return false;
                }
            }
            return true;
        }

        private bool PasswordContainsDigital(string value)
        {
            foreach (var character in value)
            {
                if (char.IsDigit(character))
                {
                    return false;
                }
            }
            return true;
        }

        private bool PasswordContainsCapitalsLetter(string value)
        {
            foreach (var character in value)
            {
                if (char.IsUpper(character))
                {
                    return false;
                }
            }
            return true;
        }

        private bool PasswordHasNotMoreThanTenCharacters(string value)
        {
            return value.Length <= 10;
        }
    }
}

