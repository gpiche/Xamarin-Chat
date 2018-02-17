using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Validations
{
    public class EmailValidation <T> : IValidationRule<T>
    {
        private readonly string _errorMessage = "Email field not valid.";
        private readonly List<char> listSpecialCharacters = new List<char> { '&', '/', '>', '<', '=', '+', '$', '%', '!', '#' };
        public string ValidateMessage { get; set; }

        public bool Check(string value, string password="")
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                ValidateMessage = "Email field is empty.";
                return false;
            }

            if (!ValueConatainsAtSign(value))
            {
                ValidateMessage = _errorMessage;
                return false;
            }

            if (ValueContainsSpecialCharacter(value))
            {
                ValidateMessage = _errorMessage;
                return false;
            }

            if (AtSignIsAtTheBeginningOrAtEnd(value))
            {
                ValidateMessage = _errorMessage;
                return false;
            }

            if (HasMoreThanOneAtSign(value))
            {
                ValidateMessage = _errorMessage;
                return false;
            }

            if (ValueHasNotExtension(value))
            {
                ValidateMessage = _errorMessage;
                return false;
            }

            if (ExtensionIsNotAtTheEnd(value))
            {
                ValidateMessage = _errorMessage;
                return false;
            }

            if (ExtensionIsAfterAtSign(value))
            {
                ValidateMessage = _errorMessage;
                return false;
            }

            return true;
        }

        private bool ValueContainsSpecialCharacter(string value)
        {
            for (var i = 0; i < value.Length; i++)
            {
                if (this.listSpecialCharacters.Contains(value[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ExtensionIsAfterAtSign(string value)
        {
            var character = value.Split('@');
            var partAfterAtSign = character[1];

            return partAfterAtSign[0] == '.';
        }

        private bool ExtensionIsNotAtTheEnd(string value)
        {
            var extension = value.Split('.');
            return extension[1] != "ca" && extension[1] != "com";
        }

        private bool ValueHasNotExtension(string value)
        {
            return !(value.Contains(".com") || value.Contains(".ca"));
        }

        private bool HasMoreThanOneAtSign(string value)
        {
            var atSignCount = 0;
            foreach (var character in value)
            {
                if (character == '@')
                {
                    atSignCount++;
                }
            }

            return atSignCount > 1;
        }

        private bool AtSignIsAtTheBeginningOrAtEnd(string value)
        {
            return value[0] == '@' || value[value.Length - 1] == '@';
        }

        private bool ValueConatainsAtSign(string value)
        {
            return value.Contains("@");
        }
    }
}
