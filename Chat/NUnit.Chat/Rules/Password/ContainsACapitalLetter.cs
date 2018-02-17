
using Chat.Validations;
using NUnit.Framework;

namespace NUnit.Lab9.Test.Rules.Password
{

        [TestFixture]
        public class ContainsACapitalLetter
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
            [TestCase("!/$%?&-*", false)]
            [TestCase("doesnotcontainsacapitalletter", false)]
            public void ValidatePasswordMethod_ContainsAtLeastACapitalLetter_returnsFalse(string key, bool expectedResult)
            {
                var reponse = _passwordValidation.Check(key);
                Assert.AreEqual(reponse, expectedResult);
            }

            [Test]
            [TestCase("alllllllllllllllhajkahsGG4", true)]
            [TestCase("containsAcapitalletter3", true)]
            public void ValidatePasswordMethod_ContainsAtLeastACapitalLetter_returnsTrue(string key, bool expectedResult)
            {
                var reponse = _passwordValidation.Check(key);
                Assert.AreEqual(reponse, expectedResult);
            }
        }

    }

