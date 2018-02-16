using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Chat.Services;
using Xamarin.Forms;

namespace Chat.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly INotificationService _notificationService;
        private readonly INavigationService _navigationService;

        public ICommand NavigateToRegisterCommand => new DelegateCommand(Register);

   
        public LoginPageViewModel(INavigationService navigationService, INotificationService notificationService) 
            : base (navigationService)
        {
            _notificationService = notificationService;
            _navigationService = navigationService;
            IsPlayServicesAvailable();
        }


        private void Register()
        {
            _navigationService.NavigateAsync("RegisterPage");
        }

    
        private void IsPlayServicesAvailable()
        {
            _notificationService.IsPlayServicesAvailable();
        }
    }
}
