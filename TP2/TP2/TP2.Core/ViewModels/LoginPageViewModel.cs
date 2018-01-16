using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TP2.Core.Domain;
using TP2.Core.Services;

namespace TP2.Core.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IRessourceService _ressourceService;
        private readonly INavigationService _navigationService;
        private string _userName;
        private string _password;
        private string _errorMessage;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }
        public ICommand AuthenticateCommand => new DelegateCommand(Login);
        public ICommand RegisterCommand => new DelegateCommand(GoToRegistrationPage);

        public LoginPageViewModel(IAuthorizationService authorizationService, INavigationService navigationService, IRessourceService ressourceService)
        {
            _authorizationService = authorizationService;
            _ressourceService = ressourceService;
            _navigationService = navigationService;
        }

        private async void Login()
        {
            var accestoken =   await _authorizationService.AuthenticateAsync(UserName, Password);

            if (!accestoken.IsNullOrEmpty)
            {
                App.CurrentUser = UserName;
                _ressourceService.AddSessionInformation(accestoken, UserName);
               await _navigationService.NavigateAsync("app:///NavigationPage/ConversationsPage");
            }
            else
            {
                ErrorMessage = "Wrong username or password.";
            }
        }

        private async void GoToRegistrationPage()
        {
            await _navigationService.NavigateAsync("RegisterPage");
        }


    }
}
