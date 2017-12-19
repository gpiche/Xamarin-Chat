
using NUnit.Framework;
using Prism.Navigation;
using TP2.Core;
using TP2.Core.Services;
using TP2.Core.ViewModels;
using TP2.UnitTests.Mock;


namespace TP2.UnitTests.ViewModels
{
    [TestFixture]
    class LoginViewModelTest
    {
        private INavigationService _navigationMock;
        private IAuthorizationService _authorizationMock;
        private IRessourceService _ressourceMock;
        private LoginPageViewModel _loginViewModel;

        [SetUp]
        public void InitializeData()
        {
            _navigationMock = new NavigationMock();
            _authorizationMock = new AuthorizationMock();
            _ressourceMock = new RessourceServiceMock();
            _loginViewModel = new LoginPageViewModel(_authorizationMock, _navigationMock, _ressourceMock);
        }

        [Test]
        public void AuthenticateCommand_MustCallNavigationService_WhenTokenIsValid()
        {
            _loginViewModel.UserName = "Valid UserName";
            _loginViewModel.Password = "Valid Password";
            var mock = (NavigationMock) _navigationMock;

            _loginViewModel.AuthenticateCommand.Execute(null);

            Assert.IsTrue(mock.IsCalled);
        }

        [Test]
        public void AuthenticateCommand_MustCallNavigationService_WithValidName()
        {
            _loginViewModel.UserName = "Valid UserName";
            _loginViewModel.Password = "Valid Password";
            var mock = (NavigationMock)_navigationMock;
            const string name = "app:///NavigationPage/ConversationsPage";

            _loginViewModel.AuthenticateCommand.Execute(null);

            Assert.AreEqual(name,mock.Name);
        }

        [Test]
        public void AuthenticateCommand_MustNotCallNavigationService_WhenTokenIsNotValid()
        {
            _loginViewModel.UserName = "Not Valid UserName";
            _loginViewModel.Password = "Not Valid Password";
            var mock = (NavigationMock)_navigationMock;

            _loginViewModel.AuthenticateCommand.Execute(null);

            Assert.IsFalse(mock.IsCalled);
        }

        [Test]
        public void AuthenticateCommand_MustAddMessageError_WhenTokenIsNotValid()
        {
            _loginViewModel.UserName = "Not Valid UserName";
            _loginViewModel.Password = "Not Valid Password";
            const string errorMessage = "Wrong username or password.";

            _loginViewModel.AuthenticateCommand.Execute(null);

            Assert.AreEqual(errorMessage,_loginViewModel.ErrorMessage);
        }

        [Test]
        public void AuthenticateCommand_MustNotAddMessageError_WhenTokenIsValid()
        {
            _loginViewModel.UserName = "Valid UserName";
            _loginViewModel.Password = "Valid Password";
            const string errorMessage = null;

            _loginViewModel.AuthenticateCommand.Execute(null);

            Assert.AreEqual(errorMessage, _loginViewModel.ErrorMessage);
        }

        [Test]
        public void AuthenticateCommand_MustGiveTokenToRessourceService_WhenTokenIsValid()
        {
            _loginViewModel.UserName = "Valid UserName";
            _loginViewModel.Password = "Valid Password";
            var mock = (RessourceServiceMock) _ressourceMock;

            _loginViewModel.AuthenticateCommand.Execute(null);

            Assert.IsTrue(mock.AddSessionIsCalled);
        }

        [Test]
        public void AuthenticateCommand_MustNotGiveTokenToRessourceService_WhenTokenIsNotValid()
        {
            _loginViewModel.UserName = "Not Valid UserName";
            _loginViewModel.Password = "Not Valid Password";
            var mock = (RessourceServiceMock)_ressourceMock;

            _loginViewModel.AuthenticateCommand.Execute(null);

            Assert.IsFalse(mock.AddSessionIsCalled);
        }
    }
}
