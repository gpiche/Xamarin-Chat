
using Chat.Validations;
using NUnit.Framework;

namespace NUnit.Lab9.Test.Rules.Password
{
    [TestFixture]
    public class ContainsANumber
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
        [TestCase("containsNoNumber", false)]
        [TestCase("ABCDOneTwoThree", false)]
        public void ValidateEmailMethod_ContainsAtLeastOneNumber_returnsFalse(string key, bool expectedResult)
        {
            var reponse = _passwordValidation.Check(key);
            Assert.AreEqual(reponse, expectedResult);
        }

        [Test]
        [TestCase("aaaaaAaaaa12345", true)]
        [TestCase("containsonly1Number", true)]
        [TestCase("ABCDaaaaaaa234567", true)]
        public void ValidateEmailMethod_ContainsAtLeastOneNumber_returnsTrue(string key, bool expectedResult)
        {
            var reponse = _passwordValidation.Check(key);
            Assert.AreEqual(reponse, expectedResult);
        }
    }
}
