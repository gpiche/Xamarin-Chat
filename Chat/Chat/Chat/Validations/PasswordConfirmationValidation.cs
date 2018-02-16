using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Validations
{
    class PasswordConfirmationValidation<T> : IValidationRule<T>
    {
        public string ValidateMessage{ get; set; }

        public bool Check(string value, string password ="")
        {
            if (value != password)
            {
                ValidateMessage = "Not same password ";
                return false;
            }

            return true;
        }
    }
}
