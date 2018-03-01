using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Validations
{
    class RegularTextFieldValidation<T> : IValidationRule<T>
    {
        public string ValidateMessage { get; set; }

        public bool Check(string value, string password = "")
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                ValidateMessage = "Must not contain white space or be empty";
                return false;
            }

            return true;
        }
    }
}
