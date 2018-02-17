
using Chat.Validations;
using NUnit.Framework;

namespace NUnit.Lab9.Test.Rules.Email
{
    [TestFixture]
    public class TestsAtSign
    {
        [TestCase("ab.com", false)]
        [TestCase("@d.com", false)]
        [TestCase("ab.com@", false)]
        [TestCase("a@@b.com", false)]
        [TestCase("aaaa@aa.", false)]
        [TestCase("aaaa@.com", false)]
        public void ValidateEmail_WhenAtSignNotExistingOrNotGoodPlaceOrHaveMoreThanOneAtSign_ReturnFalse(string currentEntry, bool expectedValue)
        {
            EmailValidation<string> validationEmail = new EmailValidation<string>();

            var actualAnswer = validationEmail.Check(currentEntry);

            Assert.AreEqual(actualAnswer, expectedValue);
        }

        [TestCase("a@b.com", true)]
        [TestCase("aaaaa@gmail.com", true)]
        [TestCase("ecole_fini_dans_4_semaine@gmail.ca", true)]
        public void ValidateEmail_WhenAtSignExistingAndGoodPlaceAndHaveJustOneAtSign_ReturnTrue(string currentEntry, bool expectedValue)
        {
            EmailValidation<string> validationEmail = new EmailValidation<string>();

            var actualAnswer = validationEmail.Check(currentEntry);

            Assert.AreEqual(actualAnswer, expectedValue);
        }
    }
}
