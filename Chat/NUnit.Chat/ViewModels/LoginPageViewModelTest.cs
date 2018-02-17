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
    class LoginPageViewModelTest
    {
        private NavigationMock _navigationMock;
        private  NotificationServiceMock _notificationServiceMock;
        private LoginPageViewModel _loginPageViewModel;


        [SetUp]
        public void TestInitialize()
        {

            _navigationMock = new NavigationMock();
            _notificationServiceMock = new NotificationServiceMock();
            _loginPageViewModel = new LoginPageViewModel(_navigationMock, _notificationServiceMock);

        }

        [Test]
        public void NavigateToRegisterCommand_ShouldNavigateToRegisterPage()
        {
            const string pageName = "RegisterPage";

            _loginPageViewModel.NavigateToRegisterCommand.Execute(null);

            Assert.IsTrue(_navigationMock.NavigateAsyncIsCalled);
            Assert.AreEqual(_navigationMock.Name, pageName );
        }

        [Test]
        public void LoginPageViewModel_MustCallNotificationServiceForGooglePlay()
        {
           
            Assert.IsTrue(_notificationServiceMock.PlayServiceAvailableIsCalled);

        }
    }
}
