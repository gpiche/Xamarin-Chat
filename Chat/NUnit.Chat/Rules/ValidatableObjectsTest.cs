using System.Linq;
using Chat.Validations;
using NUnit.Framework;
using NUnit.Lab9.Test.Mock;

namespace NUnit.Lab9.Test
{
    [TestFixture]
    class ValidatableObjectsTest
    {
        private ValidatableObject<string> _validatableObject;

        [SetUp]
        public void Initialize()
        {
            _validatableObject = new ValidatableObject<string>();
        }

        [Test]
        public void ValidateMethod_ShouldClearErrorList_BeforeSearchForNewError()
        {
            MockRule<string> mokRule = new MockRule<string>
            {
                IsValid = true
            };
            _validatableObject.Validations.Add(mokRule);
            _validatableObject.Errors.Add("test");

            _validatableObject.Validate();

            Assert.IsFalse(_validatableObject.Errors.Any());


        }

        [Test]
        public void ValidateMethod_ShouldReturnFalse_IfItsNotValid()
        {
            MockRule<string> mokRule = new MockRule<string>
            {
                IsValid = false
            };
            _validatableObject.Validations.Add(mokRule);

            var answer = _validatableObject.Validate();

            Assert.IsFalse(answer);
        }


        [Test]
        public void ValidateMethod_ShouldReturnTrue_IfItsValid()
        {
            MockRule<string> mokRule = new MockRule<string>
            {
                IsValid = true
            };
            _validatableObject.Validations.Add(mokRule);

            var answer = _validatableObject.Validate();

            Assert.IsTrue(answer);
        }

        [Test]
        public void ValidateMethod_ShouldInitializeErrorMessage_IfItsNotValid()
        {
            const string VALUE = "this is a test";
            MockRule<string> mokRule = new MockRule<string>
            {
                IsValid = false,
                ValidateMessage = VALUE
                
            };
            _validatableObject.Validations.Add(mokRule);

           _validatableObject.Validate();

            Assert.AreEqual(VALUE, _validatableObject.Errors.FirstOrDefault());
        }
    }
}
