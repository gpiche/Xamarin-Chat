
using Chat.Validations;
using NUnit.Framework;

namespace NUnit.Lab9.Test.Rules.Password
{
    [TestFixture]
    public class ContainsALowerCaseLetter
    {
        private PasswordValidation<string> _passwordValidation;
        private ValidatableObject<string> _validatableObject;

        [SetUp]
        public void TestInitialize()
        {
            _passwordValidation = new PasswordValidation<string>();
            _validatableObject = new ValidatableObject<string>();
        }

        [Test]
        [TestCase("TEST", false)]
        [TestCase("!/$%?&-*", false)]
        [TestCase("DOESNOTCONTAINSLOWERCASELETTER", false)]
        public void ValidateEmailMethod_ContainsAtLeastALowerCaseLetter_returnsFalse(string key, bool expectedResult)
        {
            var reponse = _passwordValidation.Check(key);
            Assert.AreEqual(reponse, expectedResult);
        }

        [Test]
        [TestCase("testjkgdjksSdhalkhdslakhdka3", true)]
        [TestCase("!/A$%B?&-2dasdada*", true)]
        [TestCase("Sasdfghjkddddddl3SSSSS3", true)]
        public void ValidateEmailMethod_ContainsAtLeastALowerCaseLetter_returnsTrue(string key, bool expectedResult)
        {
            var reponse = _passwordValidation.Check(key);
            Assert.AreEqual(reponse, expectedResult);
        }
    }
}
