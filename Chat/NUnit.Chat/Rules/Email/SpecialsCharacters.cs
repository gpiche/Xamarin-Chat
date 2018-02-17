
using Chat.Validations;
using NUnit.Framework;

namespace NUnit.Lab9.Test.Rules.Email
{
    [TestFixture]
    public class SpecialsCharacters
    {
        [TestCase("a$@b.com", false)]
        [TestCase("a%@b.com", false)]
        [TestCase("a&@b.com", false)]
        [TestCase("a/@b.com", false)]
        [TestCase("a!@b.com", false)]
        [TestCase("a<@b.com", false)]
        [TestCase("a=@b.com", false)]
        [TestCase("a>@b.com", false)]
        [TestCase("a+@b.com", false)]
        [TestCase("a#@b.com", false)]
        public void ValidateEmail_WhenEmailContainsBadCharacter_ReturnFalse(string currentEntry, bool expectedValue)
        {
            EmailValidation<string> validationEmail = new EmailValidation<string>();

            var actualAnswer = validationEmail.Check(currentEntry);

            Assert.AreEqual(actualAnswer, expectedValue);
        }

        [TestCase("a@b.com", true)]
        [TestCase("aaaaa@gmail.com", true)]
        [TestCase("ecole_fini_dans_4_semaine@gmail.ca", true)]
        public void ValidateEmail_WhenEmailContainsGoodCharacter_ReturnFalse(string currentEntry, bool expectedValue)
        {
            EmailValidation<string> validationEmail = new EmailValidation<string>();

            var actualAnswer = validationEmail.Check(currentEntry);

            Assert.AreEqual(actualAnswer, expectedValue);
        }
    }
}
