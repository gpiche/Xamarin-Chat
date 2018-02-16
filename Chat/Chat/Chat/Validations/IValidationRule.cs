using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Validations
{
    public interface IValidationRule<T>
    {
        string ValidateMessage { get; set; }
        bool Check(string value, string password="");
    }
}
