using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.ViewModels;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Lab9.Test.Mock;

namespace NUnit.Lab9.Test.ViewModels
{
    [TestFixture]
    class RegisterPageViewModelTest
    {
        private NavigationMock _navigationMock;
        private RegisterPageViewModel _registerPageViewModel;

        [SetUp]
        public void TestInitialize()
        {
            _navigationMock = new NavigationMock();
            _registerPageViewModel = new RegisterPageViewModel(_navigationMock);
        }

        [Test]
        public void NavigateToLoginCommand_ShouldGoBackToLoginPage()
        {
            
            _registerPageViewModel.NavigateToLoginCommand.Execute(null);

            Assert.IsTrue(_navigationMock.GoBackAsyncIsCalled);
        }
    }
}
