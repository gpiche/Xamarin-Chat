using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Validations;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace NUnit.Lab9.Test.Rules.PasswordConfirmation
{
    [TestFixture]
    public class PasswordConfirmationRules
    {
        private PasswordConfirmationValidation<string> _passwordConfirmation;
        private ValidatableObject<string> _validatableObject;

        [SetUp]
        public void TestInitialize()
        {
            _passwordConfirmation = new PasswordConfirmationValidation<string>();
            _validatableObject = new ValidatableObject<string>();
        }

        [Test]
        [TestCase("test","test1", false)]
        [TestCase("test", "tes", false)]
        [TestCase("t3y28y", "t3y28y8", false)]
        [TestCase("not the same", "password", false)]
        public void ValidatePasswordConfirmation_MustReturnFalseIfItIsNotTheSamePassword(string password, string confirmationPassword, bool expectedResult)
        {
            var reponse = _passwordConfirmation.Check(confirmationPassword, password);
            Assert.AreEqual(reponse, expectedResult);
        }

        [Test]
        [TestCase("test", "test", true)]
        [TestCase("samePassword", "samePassword", true)]
        public void ValidatePasswordConfirmation_MustReturnTrueIfItITheSamePassword(string password, string confirmationPassword, bool expectedResult)
        {
            var reponse = _passwordConfirmation.Check(confirmationPassword, password);
            Assert.AreEqual(reponse, expectedResult);
        }
    }
}
