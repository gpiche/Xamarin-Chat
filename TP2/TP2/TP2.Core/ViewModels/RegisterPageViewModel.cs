using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Navigation;
using TP2.Core.DTO;
using TP2.Core.Services;

namespace TP2.Core.ViewModels
{
    public class RegisterPageViewModel : BindableBase
    {
        private IAuthorizationService _authorizationService;
        private INavigationService _navigationService;
        private IRessourceService _ressourceservice;

        public string UserName { get; set; }
        public string Password { get; set; }

        public RegisterPageViewModel(IAuthorizationService authorizationService, INavigationService navigationService,
            IRessourceService ressourceService)
        {

            _authorizationService = authorizationService;
            _navigationService = navigationService;
            _ressourceservice = ressourceService;

        }

        public ICommand RegisterCommand => new DelegateCommand(Register);

        private async void Register()
        {
            var registrationInformation = new RegistrationInformation
            {
                Email = UserName,
                Password = Password
            };

            _ressourceservice.Register(registrationInformation);
        }

    }
}
