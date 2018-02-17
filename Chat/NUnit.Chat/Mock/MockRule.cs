using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Validations;


namespace NUnit.Lab9.Test.Mock
{
    class MockRule<T> : IValidationRule<T>
    {
        public string ValidateMessage { get; set; }
        public bool IsValid { get; set; }

        public bool Check(string value, string password="")
        {
            return IsValid;
        }
    }
}
