using Chat.Validations;
using NUnit.Framework;

namespace NUnit.Lab9.Test.Rules.Password
{
    [TestFixture]
    public class MoreThanTenCharacters
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
        [TestCase("test", false)]
        [TestCase("!/$%?&h*", false)]
        [TestCase("SuperT", false)]
        [TestCase("123456789", false)]
        public void ValidatePasswordMethod_MoreThanTenCharacters_returnsFalse(string key, bool expectedResult)
        {
            var reponse = _passwordValidation.Check(key);
            Assert.AreEqual(reponse, expectedResult);
        }

        [Test]
        [TestCase("testToHaveMoreThanTenCharacters", false)]
        [TestCase("!/$%?&h*!/$%?&*()(*&?", false)]
        [TestCase("SuperTigerPassword", false)]
        [TestCase("1234567890", false)]
        public void ValidatePasswordMethod_MoreThanTenCharacters_returnsTrue(string key, bool expectedResult)
        {
            var reponse = _passwordValidation.Check(key);
            Assert.AreEqual(reponse, expectedResult);
        }
    }
}
