
using Chat.Validations;
using NUnit.Framework;

namespace NUnit.Lab9.Test.Rules.Email
{
    [TestFixture]
    public class TextExtension
    {
        [TestCase("aaaa@aa.", false)]
        [TestCase("aaaa@.com", false)]
        [TestCase(".com@aa", false)]
        [TestCase("aaa@aa.pasbon", false)]
        public void ValidateEmail_WhenExtentionNotExistingOrNotGoodPlace_ReturnFalse(string currentEntry, bool expectedValue)
        {
            EmailValidation<string> validationEmail = new EmailValidation<string>();

            var actualAnswer = validationEmail.Check(currentEntry);

            Assert.AreEqual(actualAnswer, expectedValue);
        }

        [TestCase("a@b.com", true)]
        [TestCase("aaaaa@gmail.com", true)]
        [TestCase("ecole_fini_dans_4_semaine@gmail.ca", true)]
        public void ValidateEmail_WhenExtentionExistingOrGoodPlace_ReturnTrue(string currentEntry, bool expectedValue)
        {
            EmailValidation<string> validationEmail = new EmailValidation<string>();

            var actualAnswer = validationEmail.Check(currentEntry);

            Assert.AreEqual(actualAnswer, expectedValue);
        }
    }
}
